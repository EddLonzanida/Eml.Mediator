using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Contracts.Mef;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> : IExportable
        where T : ICommandAsync
    {
        Task SetAsync(T commandAsync);
    }
}