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
    /// <summary>
    /// Base Interface used to identify ICommandAsyncEngine&lt; T&gt;
    /// </summary>
    public interface ICommandAsyncEngine
    {
    }

#if NETFULL
    [InheritedExport]
    public interface ICommandAsyncEngine<in T> : ICommandAsyncEngine, IDisposable
#endif
#if NETCORE
    public interface ICommandAsyncEngine<in T> : ICommandAsyncEngine, IDisposable, IInheritedExport
#endif
        where T : ICommandAsync
    {
        Task ExecuteAsync(T commandAsync);
    }
}