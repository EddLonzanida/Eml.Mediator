#if NETFULL
using System;
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
using System;
#endif

namespace Eml.Mediator.Contracts
{

#if NETFULL
    [InheritedExport]
    public interface IRequestEngine<in TRequest, out TResponse> : IDisposable
#endif
#if NETCORE
    public interface IRequestEngine<in TRequest, out TResponse> : IDisposable, IInheritedExport
#endif
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        TResponse Get(TRequest request);
    }
}