using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommandEngine : ICommandEngine<TestCommand>
    {
        public void Set(TestCommand command)
        {
            command.EngineInvocationCount++;
        }
    }
}