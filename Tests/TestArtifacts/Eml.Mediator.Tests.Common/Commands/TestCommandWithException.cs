using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.CommandEngines;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestCommandWithException : ICommand
    {
        public int EngineInvocationCount { get; set; }

        /// <summary>
        /// This request will be processed by <see cref="TestCommandWithExceptionEngine"/>.
        /// </summary>
        public TestCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}
