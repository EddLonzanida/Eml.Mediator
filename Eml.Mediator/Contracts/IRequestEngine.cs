using System.ComponentModel.Composition;
using Eml.MefBootstrapper;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface IRequestEngine<in TRequest, out TResponse> : IExportable
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        TResponse Get(TRequest request);
    }
}