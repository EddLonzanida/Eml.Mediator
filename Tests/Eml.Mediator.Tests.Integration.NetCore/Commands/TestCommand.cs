using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands
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