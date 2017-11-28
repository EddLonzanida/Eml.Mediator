using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands
{
    public class TestCommandWithMultipleEngine : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithMultipleEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}