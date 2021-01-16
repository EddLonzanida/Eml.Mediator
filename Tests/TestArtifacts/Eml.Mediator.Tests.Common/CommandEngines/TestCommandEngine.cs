using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    public class TestCommandEngine : ICommandEngine<TestCommand>
    {
        public void Execute(TestCommand command)
        {
            command.EngineInvocationCount++;
        }

        public void Dispose()
        {
        }
    }
}