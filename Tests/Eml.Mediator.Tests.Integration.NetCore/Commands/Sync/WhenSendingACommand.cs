﻿using Eml.Mediator.Tests.Common.Commands;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync
{
    public class WhenSendingACommand : IntegrationTestBase
    {
        [Fact]
        public void Command_ShouldBeCalledOnce()
        {
            var command = new TestCommand();

            mediator.Set(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}