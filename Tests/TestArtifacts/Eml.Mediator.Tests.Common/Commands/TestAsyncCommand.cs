using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.CommandHandlers;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestAsyncCommand : ICommandAsync
{
    public string? CallSite { get; set; }

    public int HandlerInvocationCount { get; set; }

    /// <summary>
    ///     This request will be processed by <see cref="TestAsyncCommandHandler" />.
    /// </summary>
    public TestAsyncCommand()
    {
        HandlerInvocationCount = 0;
    }
}
