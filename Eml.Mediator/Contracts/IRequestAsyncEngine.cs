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
    /// Base Interface used to identify IRequestAsyncEngine&lt;in T1, T2&gt;
    /// </summary>
    public interface IRequestAsyncEngine
    {
    }

#if NETFULL
    [InheritedExport]
    public interface IRequestAsyncEngine<in T1, T2> : IRequestAsyncEngine, IDisposable
#endif
#if NETCORE
    public interface IRequestAsyncEngine<in T1, T2> : IRequestAsyncEngine, IDisposable, IInheritedExport
#endif
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
        Task<T2> ExecuteAsync(T1 request);
    }
}