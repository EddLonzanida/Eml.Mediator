#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
#if NETFULL
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> : IDisposable
#endif
#if NETCORE
    public interface ICommandAsyncEngine<in T> : IDisposable, IInheritedExport
#endif
        where T : ICommandAsync
    {
        Task ExecuteAsync(T commandAsync);
    }
}