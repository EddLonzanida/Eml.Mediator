using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands
{
    public class TestAsyncCommandWithNoEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithNoEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}