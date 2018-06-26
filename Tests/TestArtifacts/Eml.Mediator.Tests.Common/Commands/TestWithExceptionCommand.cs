using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithExceptionCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestWithExceptionCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}
