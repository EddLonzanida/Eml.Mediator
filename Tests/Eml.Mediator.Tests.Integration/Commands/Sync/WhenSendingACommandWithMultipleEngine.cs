using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.CommandEngines;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
{
    public class WhenSendingACommandWithMultipleEngine : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestWithMultipleEngineCommand();

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