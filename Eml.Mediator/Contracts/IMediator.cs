﻿using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    public interface IMediator
    {
        /// <summary>
        /// Method that implements ICommandEngine for type <typeparamref name="T"/> .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        void Execute<T>(T command)
            where T : ICommand;

        /// <summary>
        /// Method that implements ICommandAsyncEngine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        Task ExecuteAsync<T>(T command)
            where T : ICommandAsync;

        /// <summary>
        /// Method that implements IRequestEngine.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        T2 Execute<T1, T2>(IRequest<T1, T2> request)
            where T1 : IRequest<T1, T2>
            where T2 : IResponse;

        /// <summary>
        /// Method that implements IRequestAsyncEngine.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        Task<T2> ExecuteAsync<T1, T2>(IRequestAsync<T1, T2> request)
                where T1 : IRequestAsync<T1, T2>
                where T2 : IResponse;
    }
}