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
    public interface ICommandEngine<in T> : IDisposable
#endif
#if NETCORE
    public interface ICommandEngine<in T> : IDisposable, IInheritedExport
#endif
        where T : ICommand
    {
        void Set(T command);
    }
}