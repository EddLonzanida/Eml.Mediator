namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all IRequest&lt;TRequest, TResponse&gt;
/// </summary>
public interface IRequest
{
}

public interface IRequest<TRequest, TResponse> : IRequest
    where TRequest : IRequest<TRequest, TResponse>
    where TResponse : IResponse
{
}
