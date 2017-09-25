using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Commands.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommand : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldBeCalledOnce()
        {
            var command = new TestCommand();

            mediator.Set(command);

            command.EngineInvocationCount.ShouldBe(1);

            dotMemory.Check(memory => memory
                .GetObjects(where => where.Type.Is<TestCommandEngine>()).ObjectsCount.ShouldBe(0));
        }
    }
}