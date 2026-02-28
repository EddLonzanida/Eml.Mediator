using System.Threading.Tasks;

namespace Eml.Mediator.Contracts;

public interface IMediator
{
    /// <summary>
    ///     Method that implements ICommandEngine for type <typeparamref name="TCommand" /> .
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="command"></param>
    void Execute<TCommand>(TCommand command)
        where TCommand : ICommand;

    /// <summary>
    ///     Method that implements ICommandAsyncEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="command"></param>
    Task ExecuteAsync<TCommand>(TCommand command)
        where TCommand : ICommandAsync;

    /// <summary>
    ///     Method that implements IRequestEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    TResponse Execute<TRequest, TResponse>(IRequest<TRequest, TResponse> request)
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse;

    /// <summary>
    ///     Method that implements IRequestAsyncEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    Task<TResponse> ExecuteAsync<TRequest, TResponse>(IRequestAsync<TRequest, TResponse> request)
        where TRequest : IRequestAsync<TRequest, TResponse>
        where TResponse : IResponse;
}
