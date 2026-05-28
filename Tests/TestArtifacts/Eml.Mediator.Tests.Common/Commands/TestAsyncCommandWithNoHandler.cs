using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestAsyncCommandWithNoHandler : ICommandAsync
{
    public string? CallSite { get; set; }

    public int HandlerInvocationCount { get; set; } = 0;
}
