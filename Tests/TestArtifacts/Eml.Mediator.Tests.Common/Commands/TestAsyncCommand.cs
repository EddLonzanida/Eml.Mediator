using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}