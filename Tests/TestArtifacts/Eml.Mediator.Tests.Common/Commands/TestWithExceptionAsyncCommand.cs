using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithExceptionAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestWithExceptionAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}