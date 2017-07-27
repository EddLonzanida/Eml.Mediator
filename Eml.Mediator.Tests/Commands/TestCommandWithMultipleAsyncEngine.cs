using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands
{
    public class TestCommandWithMultipleAsyncEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithMultipleAsyncEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}