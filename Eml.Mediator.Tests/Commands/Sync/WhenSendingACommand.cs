using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Commands.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommand : IntegrationTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void TheCommandEngineShouldHaveBeenCalledExactlyOnce()
        {
            var command = new TestCommand();

            command.Set();

            command.EngineInvocationCount.ShouldBe(1);

            dotMemory.Check(memory => memory
                .GetObjects(where => where.Type.Is<TestCommandEngine>()).ObjectsCount.ShouldBe(0));
        }
    }
}