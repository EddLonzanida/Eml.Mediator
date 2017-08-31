using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.MefBootstrapper;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface IRequestAsyncEngine<in T1, T2> : IExportable
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
        Task<T2> GetAsync(T1 request);
    }
}