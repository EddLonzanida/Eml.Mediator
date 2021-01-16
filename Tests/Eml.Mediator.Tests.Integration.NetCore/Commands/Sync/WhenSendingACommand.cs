using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync
{
    public class WhenSendingACommand : IntegrationTestDiBase
    {
        [Fact]
        public void Command_ShouldBeCalledOnce()
        {
            var command = new TestCommand();    //<-Data

            mediator.Execute(command);          //<-Execute

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}