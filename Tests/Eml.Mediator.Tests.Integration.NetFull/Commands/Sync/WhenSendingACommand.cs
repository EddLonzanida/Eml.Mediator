using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Commands.Sync
{
    public class WhenSendingACommand : IntegrationTestBase
    {
        [Fact]
        public void Command_ShouldBeCalledOnce()
        {
            var command = new TestCommand();

            mediator.Set(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}