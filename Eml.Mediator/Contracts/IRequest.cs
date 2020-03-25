namespace Eml.Mediator.Contracts
{
    /// <summary>
    /// Base Interface used to identify IRequest&lt;TRequest, TResponse&gt;
    /// </summary>
    public interface IRequest
    {
    }

    public interface IRequest<TRequest, TResponse> : IRequest
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
    }
}