using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Commands.Sync
{
    public class WhenSendingACommandWithMultipleEngine : IntegrationTestBase
    {
        [Fact]
        public void Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleEngine();

            Should.Throw<MultipleEngineException>(() => mediator.Set(command));
        }
    }
}