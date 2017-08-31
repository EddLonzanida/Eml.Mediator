using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.MefBootstrapper;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> : IExportable
        where T : ICommandAsync
    {
        Task SetAsync(T commandAsync);
    }
}