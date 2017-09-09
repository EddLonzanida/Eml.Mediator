using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> : IDisposable
        where T : ICommandAsync
    {
        Task SetAsync(T commandAsync);
    }
}