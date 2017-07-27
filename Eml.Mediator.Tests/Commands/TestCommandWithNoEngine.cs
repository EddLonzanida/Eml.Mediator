using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands
{
    public class TestCommandWithNoEngine : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithNoEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}