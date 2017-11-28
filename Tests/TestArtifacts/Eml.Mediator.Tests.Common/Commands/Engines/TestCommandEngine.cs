#if NETFULL
using System.ComponentModel.Composition;
#endif
using Eml.Mediator.Contracts;namespace Eml.Mediator.Tests.Common.Commands.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestCommandEngine : ICommandEngine<TestCommand>
    {
        public void Set(TestCommand command)
        {
            command.EngineInvocationCount++;
        }

        public void Dispose()
        {
        }
    }
}