namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all IRequestEngine&lt;in TRequest, out TResponse&gt;
///     Transient.
/// </summary>
public interface IRequestEngine
{
}

/// <summary>
///     Transient.
/// </summary>
public interface IRequestEngine<in TRequest, out TResponse> : IRequestEngine
    where TRequest : IRequest<TRequest, TResponse>
    where TResponse : IResponse
{
    TResponse Execute(TRequest request);
}
