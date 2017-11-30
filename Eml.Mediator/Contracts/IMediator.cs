#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{

#if NETFULL
    [InheritedExport]
    public interface IMediator
#endif
#if NETCORE
    public interface IMediator : IInheritedExport
#endif
    {
        /// <summary>
        /// Method that implements ICommandEngine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        void Set<T>(T command)
            where T : ICommand;

        /// <summary>
        /// Method that implements ICommandAsyncEngine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        Task SetAsync<T>(T command)
            where T : ICommandAsync;

        /// <summary>
        /// Method that implements IRequestEngine.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        T2 Get<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse;

        /// <summary>
        /// Method that implements IRequestAsyncEngine.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        Task<T2> GetAsync<T1, T2>(IRequestAsync<T1, T2> request)
                where T1 : IRequestAsync<T1, T2>
                where T2 : IResponse;
    }
}