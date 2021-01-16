using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.CommandEngines;

namespace Eml.Mediator.Tests.Common.Commands
{
    public class TestCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        /// <summary>
        /// This request will be processed by <see cref="TestCommandEngine"/>.
        /// </summary>
        public TestCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}