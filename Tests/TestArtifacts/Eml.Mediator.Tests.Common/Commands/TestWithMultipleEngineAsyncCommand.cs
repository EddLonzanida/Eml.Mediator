using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithMultipleEngineAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestWithMultipleEngineAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}