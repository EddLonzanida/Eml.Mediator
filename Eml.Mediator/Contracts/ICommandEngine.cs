using System.ComponentModel.Composition;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandEngine<in T> 
        where T : ICommand
    {
        void Set(T command);
    }
}