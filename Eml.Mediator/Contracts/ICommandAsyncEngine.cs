using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> 
        where T : ICommandAsync
    {
        Task SetAsync(T commandAsync);
    }
}