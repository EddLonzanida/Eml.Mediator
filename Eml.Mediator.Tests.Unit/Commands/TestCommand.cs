using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands
{
    public class TestCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}