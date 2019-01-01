using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommand1Engine : ICommandEngine<TestWithMultipleEngineCommand>
    {
        public void Execute(TestWithMultipleEngineCommand command)
        {
            command.EngineInvocationCount++;
        }

        public void Dispose()
        {
        }
    }
}