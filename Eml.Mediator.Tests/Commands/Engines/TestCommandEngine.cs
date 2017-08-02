using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommandEngine : ICommandEngine<TestCommand>
    {
        public void Set(TestCommand command)
        {
            command.EngineInvocationCount++;
        }
    }
}