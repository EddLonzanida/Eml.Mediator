#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System;

namespace Eml.Mediator.Contracts
{
    /// <summary>
    /// Base Interface used to identify IRequestEngine&lt;in TRequest, out TResponse&gt;
    /// </summary>
    public interface IRequestEngine
    {
    }

#if NETFULL
    [InheritedExport]
    public interface IRequestEngine<in TRequest, out TResponse> : IRequestEngine, IDisposable
#endif
#if NETCORE
    public interface IRequestEngine<in TRequest, out TResponse> : IRequestEngine, IDisposable, IInheritedExport
#endif
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        TResponse Execute(TRequest request);
    }
}