using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands;

public class TestAsyncCommandWithNoEngine : ICommandAsync
{
    public int EngineInvocationCount { get; set; }

    public TestAsyncCommandWithNoEngine()
    {
        EngineInvocationCount = 0;
    }
}
