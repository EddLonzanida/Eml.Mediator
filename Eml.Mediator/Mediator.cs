using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;

namespace Eml.Mediator
{
    [Export(typeof(IMediator))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Mediator : IMediator
    {
        public static IClassFactory ClassFactory { get; private set; }

        public static void SetClassFactory(IClassFactory classFactory)
        {
            if (ClassFactory == null)
            {
                ClassFactory = classFactory;
            }
        }
        //private readonly IClassFactory _classFactory;

        //[ImportingConstructor]
        //public Mediator(IClassFactory classFactory)
        //{
        //    if (ClassFactory == null)
        //    {
        //        ClassFactory = classFactory;
        //    }
        //    _classFactory = classFactory;
        //}

        public void Set<T>(T command) where T : ICommand
        {
            var engines = ClassFactory.Container.GetExports<ICommandEngine<T>>().ToList();
            if (engines.Count > 1)
            {
                ClassFactory.Container.ReleaseExports(engines);
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Command engines:{aMsgs}");
            }

            var syncEngine = engines.FirstOrDefault();
            syncEngine?.Value.Set(command);

            if (syncEngine == null)
                throw new MissingEngineException($"Could not find a command engine for command of type {typeof(T).Name}. " +
                                                 $"Check if the class is implementing the interface: ICommandEngine." +
                                                 $"Check MefLoader.Init for missing parts needed by the ImportingConstructor.");

            ClassFactory.Container.ReleaseExports(engines);
        }

        public async Task SetAsync<T>(T commandAsync)
            where T : ICommandAsync
        {
            var engines = ClassFactory.Container.GetExports<ICommandAsyncEngine<T>>().ToList();
            if (engines.Count > 1)
            {
                ClassFactory.Container.ReleaseExports(engines);
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Command engines:{aMsgs}");
            }

            var asyncEngine = engines.FirstOrDefault();

            if (asyncEngine != null)
            {
                await asyncEngine.Value.SetAsync(commandAsync).ConfigureAwaitFalse();
                ClassFactory.Container.ReleaseExports(engines);
            }
            else throw new MissingEngineException($"Could not find a command engine for command of type {typeof(T).Name}. " +
                                                  $"Check if the class is implementing the interface: ICommandAsyncEngine." +
                                                  $"Check MefLoader.Init for missing parts needed by the ImportingConstructor.");
        }

        public T2 Get<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse
        {
            var engines = ClassFactory.Container.GetExports<IRequestEngine<T1, T2>>().ToList();
            if (engines.Count > 1)
            {
                ClassFactory.Container.ReleaseExports(engines);
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Request engines:{aMsgs}");
            }

            var syncEngine = engines.FirstOrDefault();

            if (syncEngine == null)
                throw new MissingEngineException(
                    $"Could not find a Request engine for request of type {typeof(T1).Name}. " +
                    $"Check if the class is implementing the interface: IRequestEngine." +
                    $"Check MefLoader.Init for missing parts needed by the ImportingConstructor.");

            var result = syncEngine.Value.Get((T1)request);
            ClassFactory.Container.ReleaseExports(engines);

            return result;
        }

        public async Task<T2> GetAsync<T1, T2>(IRequestAsync<T1, T2> request)
            where T1 : IRequestAsync<T1, T2>
            where T2 : IResponse
        {
            var engines = ClassFactory.Container.GetExports<IRequestAsyncEngine<T1, T2>>().ToList();
            if (engines.Count > 1)
            {
                ClassFactory.Container.ReleaseExports(engines);
                var aMsgs = GetMultipleEngineExceptionMessage(engines);
                throw new MultipleEngineException($"Check the following Request engines:{aMsgs}");
            }

            var asyncEngine = engines.FirstOrDefault();

            if (asyncEngine == null)
                throw new MissingEngineException(
                    $"Could not find a Request engine for request of type {typeof(T1).Name}. " +
                    $"Check if the class is implementing the interface: IRequestAsyncEngine." +
                    $"Check MefLoader.Init for missing parts needed by the ImportingConstructor.");

            var result = await asyncEngine.Value.GetAsync((T1)request).ConfigureAwaitFalse();
            ClassFactory.Container.ReleaseExports(engines);

            return result;
        }

        private static string GetMultipleEngineExceptionMessage<T>(IEnumerable<T> engines)
        {
            var aMsgs = engines.ToList().ConvertAll(r => r.GetType().FullName);
            aMsgs = aMsgs.ConvertAll(r => $"->{r}");
            return $"{Environment.NewLine}{string.Join(Environment.NewLine, aMsgs)}{Environment.NewLine}";
        }
    }
}
