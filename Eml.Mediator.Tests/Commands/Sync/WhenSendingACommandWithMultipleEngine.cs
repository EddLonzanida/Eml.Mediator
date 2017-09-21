using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Commands.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommandWithMultipleEngine : IntegrationTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleEngine();

            Should.Throw<MultipleEngineException>(() => mediator.Set(command));
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestCommand1Engine>())
                    .ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<TestCommand2Engine>())
                    .ObjectsCount.ShouldBe(0);
            });
        }
    }
}