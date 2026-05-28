using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandHandlers;

/// <summary>
///     DI signature: ICommandHandler&lt;TestCommand&gt;.
///     <inheritdoc cref="ICommandHandler{TestCommand}" />
/// </summary>
public class TestCommandHandler : ICommandHandler<TestCommand>
{
    public void Execute(TestCommand command)
    {
        command.HandlerInvocationCount++;
    }
}
