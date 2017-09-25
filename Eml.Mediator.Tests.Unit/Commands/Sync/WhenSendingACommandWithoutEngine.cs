using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    public class WhenSendingACommandWithoutEngine : UnitTestBase
    {
        [Test]
        public void Command_ShouldThrowMissingEngineException()
        {
            var command = new TestCommandWithNoEngine();

            Should.Throw<MissingEngineException>(() => mediator.Set(command));
        }
    }
}
