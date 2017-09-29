using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    public class WhenSendingACommand : UnitTestBase
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