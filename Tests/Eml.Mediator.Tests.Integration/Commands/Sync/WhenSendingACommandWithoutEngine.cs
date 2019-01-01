using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
{
    public class WhenSendingACommandWithoutEngine : IntegrationTestDiBase
    {
        [Fact]
        public void Command_ShouldThrowMissingEngineException()
        {
            var command = new TestWithNoEngineCommand();

            Should.Throw<MissingEngineException>(() => mediator.Execute(command));
        }
    }
}
