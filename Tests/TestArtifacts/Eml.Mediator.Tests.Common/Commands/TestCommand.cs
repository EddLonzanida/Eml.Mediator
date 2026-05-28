using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.CommandHandlers;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestCommand : ICommand
{
    public string? CallSite { get; set; }

    public int HandlerInvocationCount { get; set; }

    /// <summary>
    ///     This request will be processed by <see cref="TestCommandHandler" />.
    /// </summary>
    public TestCommand()
    {
        HandlerInvocationCount = 0;
    }
}
