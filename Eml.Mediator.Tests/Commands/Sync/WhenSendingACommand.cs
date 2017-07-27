using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommand : IntegrationTestBase
    {
        [Test]
        public void TheCommandEngineShouldHaveBeenCalledExactlyOnce()
        {
            var command = new TestCommand();

            command.Set();

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}