using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.CommandEngines;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        /// <summary>
        /// This request will be processed by <see cref="TestAsyncCommandEngine"/>.
        /// </summary>
        public TestAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}