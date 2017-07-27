using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands
{
    public class TestCommandWithNoAsyncEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithNoAsyncEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}