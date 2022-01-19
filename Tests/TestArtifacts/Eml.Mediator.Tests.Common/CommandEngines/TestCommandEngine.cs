using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    /// <summary>
    /// DI signature: ICommandEngine&lt;TestCommand&gt;.
    /// <inheritdoc cref="ICommandEngine{TestCommand}"/>
    /// </summary>
    public class TestCommandEngine : ICommandEngine<TestCommand>
    {
        public void Execute(TestCommand command)
        {
            command.EngineInvocationCount++;
        }
    }
}