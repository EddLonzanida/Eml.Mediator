using Eml.Mediator.Tests.Common.CommandEngines;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
{
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