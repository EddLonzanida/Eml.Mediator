using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.CommandHandlers;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestCommandWithException : ICommand
{
    public string? CallSite { get; set; }

    public int HandlerInvocationCount { get; set; }

    /// <summary>
    ///     This request will be processed by <see cref="TestCommandWithExceptionHandler" />.
    /// </summary>
    public TestCommandWithException()
    {
        HandlerInvocationCount = 0;
    }
}
