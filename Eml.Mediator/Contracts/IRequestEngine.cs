using System.ComponentModel.Composition;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface IRequestEngine<in TRequest, out TResponse> 
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        TResponse Get(TRequest request);
    }
}