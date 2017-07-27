using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands
{
    public class TestCommandAsyncWithException : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandAsyncWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}