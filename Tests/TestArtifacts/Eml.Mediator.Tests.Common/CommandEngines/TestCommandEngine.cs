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