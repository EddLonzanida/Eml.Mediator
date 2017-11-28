using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands
{
    public class TestAsyncCommandWithMultipleEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithMultipleEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}