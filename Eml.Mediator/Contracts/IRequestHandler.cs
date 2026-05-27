namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all IRequestEngine&lt;in TRequest, out TResponse&gt;
///     Transient.
/// </summary>
public interface IRequestHandler : IHandler
{
}

/// <summary>
///     Transient.
/// </summary>
public interface IRequestHandler<in TRequest, out TResponse> : IRequestHandler
    where TRequest : IRequest<TRequest, TResponse>
    where TResponse : IResponse
{
    TResponse Execute(TRequest request);
}
