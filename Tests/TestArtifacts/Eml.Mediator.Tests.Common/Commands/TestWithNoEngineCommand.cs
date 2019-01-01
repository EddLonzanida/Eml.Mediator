using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithNoEngineCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestWithNoEngineCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}