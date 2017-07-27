using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    public interface IMediator
    {
        /// <summary>
        /// Method used to invoke classes that implements ICommandEngine
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        void Set<T>(T command) 
            where T : ICommand;

        /// <summary>
        /// Method used to invoke classes that implements ICommandAsyncEngine
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task SetAsync<T>(T command) 
            where T : ICommandAsync;

        /// <summary>
        /// Method used to invoke classes that implements IRequestEngine
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        T2 Get<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse;

        /// <summary>
        /// Method used to invoke classes that implements IRequestAsyncEngine
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<T2> GetAsync<T1, T2>(IRequestAsync<T1, T2> request)
            where T1 : IRequestAsync<T1, T2>
            where T2 : IResponse;
    }
}