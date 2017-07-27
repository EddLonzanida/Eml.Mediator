using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands
{
    public class TestCommandAsync : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandAsync()
        {
            EngineInvocationCount = 0;
        }
    }
}