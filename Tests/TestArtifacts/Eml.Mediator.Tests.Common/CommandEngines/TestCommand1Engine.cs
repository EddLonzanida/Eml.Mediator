#if NETFULL
using System.ComponentModel.Composition;
#endif
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestCommand1Engine : ICommandEngine<TestCommandWithMultipleEngine>
    {
        public void Execute(TestCommandWithMultipleEngine command)
        {
            command.EngineInvocationCount++;
        }

        public void Dispose()
        {
        }
    }
}