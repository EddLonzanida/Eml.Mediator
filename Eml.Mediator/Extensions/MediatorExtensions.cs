using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Extensions
{
    public static class MediatorExtensions
    {
        /// <summary>
        /// Method used to invoke classes that implements IRequestEngine
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static T2 Get<T1, T2>(this IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse
        {
            var mediator = Mediator.ClassFactory.Container.GetExportedValue<IMediator>();
            return mediator.Get(request);
        }

        /// <summary>
        /// Method used to invoke classes that implements IRequestAsyncEngine
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T2> GetAsync<T1, T2>(this IRequestAsync<T1, T2> request)
            where T1 : IRequestAsync<T1, T2>
            where T2 : IResponse
        {
            var mediator = Mediator.ClassFactory.Container.GetExportedValue<IMediator>();
            return await mediator.GetAsync(request);
        }

        /// <summary>
        /// Method used to invoke classes that implements ICommandEngine
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        public static void Set<T>(this T command)
            where T : ICommand
        {
            var mediator = Mediator.ClassFactory.Container.GetExportedValue<IMediator>();
            mediator.Set(command);
        }

        /// <summary>
        /// Method used to invoke classes that implements ICommandAsyncEngine
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandAsync"></param>
        /// <returns></returns>
        public static async Task SetAsync<T>(this T commandAsync)
            where T : ICommandAsync
        {
            var mediator = Mediator.ClassFactory.Container.GetExportedValue<IMediator>();
            await mediator.SetAsync(commandAsync);
        }
    }
}
