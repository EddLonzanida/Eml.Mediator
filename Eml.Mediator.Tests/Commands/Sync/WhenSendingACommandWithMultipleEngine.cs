using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommandWithMultipleEngine : IntegrationTestBase
    {
        [Test]
        public void ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleEngine();

            Should.Throw<MultipleEngineException>(() => command.Set());
        }
    }
}