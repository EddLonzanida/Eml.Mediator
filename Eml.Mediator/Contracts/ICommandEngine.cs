using System;
using System.ComponentModel.Composition;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandEngine<in T> : IDisposable
        where T : ICommand
    {
        void Set(T command);
    }
}