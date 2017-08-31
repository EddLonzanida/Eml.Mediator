using System.ComponentModel.Composition;
using Eml.MefBootstrapper;

namespace Eml.Mediator.Contracts
{
    [InheritedExport]
    public interface ICommandEngine<in T> : IExportable
        where T : ICommand
    {
        void Set(T command);
    }
}