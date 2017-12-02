using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
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
