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
    /// Base Interface used to identify ICommandEngine&lt; T&gt;
    /// </summary>
    public interface ICommandEngine
    {
    }

#if NETFULL
    [InheritedExport]
    public interface ICommandEngine<in T> : ICommandEngine, IDisposable
#endif
#if NETCORE
    public interface ICommandEngine<in T> : ICommandEngine, IDisposable, IInheritedExport
#endif
        where T : ICommand
    {
        void Execute(T command);
    }
}