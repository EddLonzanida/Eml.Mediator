#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using System.Composition;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;

namespace Eml.Mediator
{
#if NETCORE
    [Shared]
#endif
    [Export(typeof(IMediator))]
    public class Mediator : IMediator
    {
        private readonly IClassFactory classFactory;

        [ImportingConstructor]
        public Mediator(IClassFactory classFactory)
        {
            this.classFactory = classFactory;
        }

        public void Execute<T>(T command)
            where T : ICommand
        {
            var engines = classFactory.GetLazyExports<ICommandEngine<T>>();

            try
            {
                if (engines.Count > 1)
                {
#if NETFULL
                    classFactory.ReleaseExports(engines);
#endif
                    var aMessages = GetMultipleEngineExceptionMessage(engines);

                    throw new MultipleEngineException($"Check the following Command engines:{aMessages}");
                }

                var syncEngine = engines.FirstOrDefault();

                if (syncEngine == null)
                    throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(T)}. " +
                                                     $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandEngine<T>)}" +
                                                     $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandEngine<T>)} are all discoverable." +
                                                     $"{Environment.NewLine}Check if the class is implementing the interface: ICommandEngine." +
                                                     $"{Environment.NewLine}Check MefLoader.Init for missing parts needed by the ImportingConstructor.");
                var engine = syncEngine.Instance();

                engine.Execute(command);
            }
            finally
            {
#if NETFULL
                classFactory.ReleaseExports(engines);
#endif
            }
        }

        public async Task ExecuteAsync<T>(T commandAsync)
            where T : ICommandAsync
        {
            var engines = classFactory.GetLazyExports<ICommandAsyncEngine<T>>().ToList();

            try
            {
                if (engines.Count > 1)
                {
#if NETFULL
                    classFactory.ReleaseExports(engines);
#endif

                    var aMessages = GetMultipleEngineExceptionMessage(engines);

                    throw new MultipleEngineException($"Check the following Command engines:{aMessages}");
                }

                var asyncEngine = engines.FirstOrDefault();

                if (asyncEngine == null)
                    throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(T)}. " +
                                                     $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandAsyncEngine<T>)}" +
                                                     $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandAsyncEngine<T>)} are all discoverable." +
                                                     $"{Environment.NewLine}Check if the class is implementing the interface: ICommandAsyncEngine." +
                                                     $"{Environment.NewLine}Check MefLoader.Init for missing parts needed by the ImportingConstructor.");

                await asyncEngine.Instance().ExecuteAsync(commandAsync);
            }
            finally
            {
#if NETFULL
                classFactory.ReleaseExports(engines);
#endif
            }
        }

        public T2 Execute<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse
        {
            var engines = classFactory.GetLazyExports<IRequestEngine<T1, T2>>().ToList();

            try
            {
                if (engines.Count > 1)
                {
#if NETFULL
                    classFactory.ReleaseExports(engines);
#endif
                    var aMessages = GetMultipleEngineExceptionMessage(engines);

                    throw new MultipleEngineException($"Check the following Request engines:{aMessages}");
                }

                var syncEngine = engines.FirstOrDefault();

                if (syncEngine == null)
                    throw new MissingEngineException(
                        $"{Environment.NewLine}Could not find a Request of type {typeof(T1)}. " +
                        $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestEngine<T1, T2>)}" +
                        $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestEngine<T1, T2>)} are all discoverable." +
                        $"{Environment.NewLine}Check if the class is implementing the interface: IRequestEngine." +
                        $"{Environment.NewLine}Check MefLoader.Init for missing parts needed by the ImportingConstructor.");

                var engine = syncEngine.Instance();

                return engine.Execute((T1)request);
            }
            finally
            {
#if NETFULL
                classFactory.Container.ReleaseExports(engines);
                //classFactory.ReleaseExports(engines);
#endif
            }
        }

        public async Task<T2> ExecuteAsync<T1, T2>(IRequestAsync<T1, T2> request)
            where T1 : IRequestAsync<T1, T2>
            where T2 : IResponse
        {
            var engines = classFactory.GetLazyExports<IRequestAsyncEngine<T1, T2>>().ToList();

            try
            {
                if (engines.Count > 1)
                {
#if NETFULL
                    classFactory.ReleaseExports(engines);
#endif
                    var aMsgs = GetMultipleEngineExceptionMessage(engines);

                    throw new MultipleEngineException($"Check the following Request engines:{aMsgs}");
                }

                var asyncEngine = engines.FirstOrDefault();

                if (asyncEngine == null)
                    throw new MissingEngineException(
                            $"{Environment.NewLine}Could not find a Request of type {typeof(T1)}." +
                            $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestAsyncEngine<T1, T2>)}" +
                            $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestAsyncEngine<T1, T2>)} are all discoverable." +
                            $"{Environment.NewLine}To check, put a breakpoint and examine the container: MefBootstrapper.classFactory.Mef." +
                            $"{Environment.NewLine}Check if the class is implementing IRequestAsyncEngine." +
                            $"{Environment.NewLine}Check if any of the constructor parameters for {typeof(T1).Name} are also in the container.");

                return await asyncEngine.Instance().ExecuteAsync((T1)request);
            }
            finally
            {
#if NETFULL
                classFactory.ReleaseExports(engines);
#endif
            }
        }

        private static string GetMultipleEngineExceptionMessage<T>(IEnumerable<T> engines)
        {
            var aMsgs = engines.ToList().ConvertAll(r => r.GetType().FullName);

            aMsgs = aMsgs.ConvertAll(r => $"->{r}");

            return $"{Environment.NewLine}{string.Join(Environment.NewLine, aMsgs)}{Environment.NewLine}";
        }
    }
}