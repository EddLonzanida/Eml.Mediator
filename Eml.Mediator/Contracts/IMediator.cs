using System.Threading.Tasks;

namespace Eml.Mediator.Contracts;

public interface IMediator
{
    /// <summary>
    ///     Method that implements ICommandEngine for type <typeparamref name="T" /> .
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="command"></param>
    void Execute<T>(T command)
        where T : ICommand;

    /// <summary>
    ///     Method that implements ICommandAsyncEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="command"></param>
    Task ExecuteAsync<T>(T command)
        where T : ICommandAsync;

    /// <summary>
    ///     Method that implements IRequestEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="request"></param>
    T2 Execute<T1, T2>(IRequest<T1, T2> request)
        where T1 : IRequest<T1, T2>
        where T2 : IResponse;

    /// <summary>
    ///     Method that implements IRequestAsyncEngine.
    ///     <para>This will always create a new instance of the engine.</para>
    ///     <para>The lifetime of the engine ends as soon as this method is completed.</para>
    ///     <para>If this behavior does not suit your needs, just use dependency injection via the constructor.</para>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="request"></param>
    Task<T2> ExecuteAsync<T1, T2>(IRequestAsync<T1, T2> request)
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse;
}
