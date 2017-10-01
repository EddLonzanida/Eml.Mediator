using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    public class WhenSendingACommandWithoutEngine : UnitTestBase
    {
        [Fact]
        public void Command_ShouldThrowMissingEngineException()
        {
            var command = new TestCommandWithNoEngine();

            Should.Throw<MissingEngineException>(() => mediator.Set(command));
        }
    }
}
