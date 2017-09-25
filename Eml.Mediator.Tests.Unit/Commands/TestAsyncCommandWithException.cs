using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands
{
    public class TestAsyncCommandWithException : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}