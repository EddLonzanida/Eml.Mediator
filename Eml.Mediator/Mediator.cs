using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.Contracts.Factories;
using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;

namespace Eml.Mediator
{
    [Export(typeof(IMediator))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Mediator : IMediator
    {
        private readonly IClassFactory _classFactory;

        [ImportingConstructor]
        public Mediator(IClassFactory classFactory)
        {
            _classFactory = classFactory;
        }

        public void Set<T>(T command) where T : ICommand
        {
            var engines = _classFactory.Container.GetExportedValues<ICommandEngine<T>>().ToList();
            if (engines.Count > 1)
            {
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Command engines:{aMsgs}");
            }

            var syncEngine = engines.FirstOrDefault();
            syncEngine?.Set(command);

            if (syncEngine == null)
                throw new MissingEngineException($"Could not find a command engine for command of type {typeof(T).Name}. Check if the class is implementing the interface: ICommandEngine.");
        }

        public async Task SetAsync<T>(T commandAsync) 
            where T : ICommandAsync
        {
            var engines = _classFactory.Container.GetExportedValues<ICommandAsyncEngine<T>>().ToList();
            if (engines.Count > 1)
            {
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Command engines:{aMsgs}");
            }

            var asyncEngine = engines.FirstOrDefault();

            if (asyncEngine != null)
                await asyncEngine.SetAsync(commandAsync).ConfigureAwaitFalse();
            else
                throw new MissingEngineException($"Could not find a command engine for command of type {typeof(T).Name}. Check if the class is implementing the interface: ICommandAsyncEngine.");
        }

        public T2 Get<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse
        {
            var engines = _classFactory.Container.GetExportedValues<IRequestEngine<T1, T2>>().ToList();
            if (engines.Count > 1)
            {
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Request engines:{aMsgs}");
            }

            var syncEngine = engines.FirstOrDefault();

            if (syncEngine != null)
                return syncEngine.Get((T1)request);

            throw new MissingEngineException($"Could not find a Request engine for request of type {typeof(T1).Name}. Check if the class is implementing the interface: IRequestEngine.");
        }

        public async Task<T2> GetAsync<T1, T2>(IRequestAsync<T1, T2> request)
            where T1 : IRequestAsync<T1, T2>
            where T2 : IResponse
        {
            var engines = _classFactory.Container.GetExportedValues<IRequestAsyncEngine<T1, T2>>().ToList();
            if (engines.Count > 1)
            {
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Request engines:{aMsgs}");
            }

            var asyncEngine = engines.FirstOrDefault();

            if (asyncEngine != null)
                return await asyncEngine.GetAsync((T1)request).ConfigureAwaitFalse();

            throw new MissingEngineException($"Could not find a Request engine for request of type {typeof(T1).Name}. Check if the class is implementing the interface: IRequestAsyncEngine.");
        }

        private static string GetMultipleEngineExceptionMessage<T>(IEnumerable<T> engines)
        {
            var aMsgs = engines.ToList().ConvertAll(r => r.GetType().FullName);
            aMsgs = aMsgs.ConvertAll(r => $"->{r}");
            return $"{Environment.NewLine}{string.Join(Environment.NewLine, aMsgs)}{Environment.NewLine}";
        }
    }
}
