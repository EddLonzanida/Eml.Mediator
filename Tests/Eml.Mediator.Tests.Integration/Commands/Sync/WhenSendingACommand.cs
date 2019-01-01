using Eml.Mediator.Tests.Common.CommandEngines;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using JetBrains.dotMemoryUnit;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
{
    public class WhenSendingACommand : IntegrationTestDiBase
    {
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldBeCalledOnce()
        {
            var command = new TestCommand();

            mediator.Execute(command);

            command.EngineInvocationCount.ShouldBe(1);

            dotMemory.Check(memory => memory
                .GetObjects(where => where.Type.Is<TestCommandEngine>()).ObjectsCount.ShouldBe(0));
        }
    }
}