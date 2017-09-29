using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands
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