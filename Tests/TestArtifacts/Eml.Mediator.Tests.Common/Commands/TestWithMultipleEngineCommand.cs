using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithMultipleEngineCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestWithMultipleEngineCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}