#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestCommand1Engine : ICommandEngine<TestCommandWithMultipleEngine>
    {
        public void Set(TestCommandWithMultipleEngine command)
        {
            command.EngineInvocationCount++;
        }

        public void Dispose()
        {
        }
    }
}