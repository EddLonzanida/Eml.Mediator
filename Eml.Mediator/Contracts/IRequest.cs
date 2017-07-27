namespace Eml.Mediator.Contracts
{
    public interface IRequest<TRequest, TResponse>
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
    }
}