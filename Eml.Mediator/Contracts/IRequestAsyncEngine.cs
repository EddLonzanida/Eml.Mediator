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
    public interface IRequestAsyncEngine<in T1, T2> : IDisposable
#endif
#if NETCORE
    public interface IRequestAsyncEngine<in T1, T2> : IDisposable, IInheritedExport
#endif
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
        Task<T2> GetAsync(T1 request);
    }
}