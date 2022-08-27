using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines;

public class TestCommand1Engine : ICommandEngine<TestCommandWithMultipleEngine>
{
    public void Execute(TestCommandWithMultipleEngine command)
    {
        command.EngineInvocationCount++;
    }
}
