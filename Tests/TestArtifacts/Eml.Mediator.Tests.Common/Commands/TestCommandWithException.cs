using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestCommandWithException : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}
