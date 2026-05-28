using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandHandlers;

public class TestCommand1Handler : ICommandHandler<TestCommandWithMultipleHandler>
{
    public void Execute(TestCommandWithMultipleHandler command)
    {
        command.HandlerInvocationCount++;
    }
}
