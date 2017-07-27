using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommand1Engine : ICommandEngine<TestCommandWithMultipleEngine>
    {
        public void Set(TestCommandWithMultipleEngine command)
        {
            command.EngineInvocationCount++;
        }
    }
}