using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommand1Engine : ICommandEngine<TestCommandWithMultipleEngine>
    {
        public void Set(TestCommandWithMultipleEngine command)
        {
            command.EngineInvocationCount++;
        }
    }
}