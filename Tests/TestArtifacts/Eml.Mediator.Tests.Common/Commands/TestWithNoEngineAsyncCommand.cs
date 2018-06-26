using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestWithNoEngineAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestWithNoEngineAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}