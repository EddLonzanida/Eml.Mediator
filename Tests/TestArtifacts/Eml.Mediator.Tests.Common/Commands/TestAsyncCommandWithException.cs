using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.CommandEngines;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestAsyncCommandWithException : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        /// <summary>
        /// This request will be processed by <see cref="TestAsyncCommandWithExceptionEngine"/>.
        /// </summary>
        public TestAsyncCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}