using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestCommandWithMultipleEngine : ICommand
{
    public int EngineInvocationCount { get; set; } = 0;
}
