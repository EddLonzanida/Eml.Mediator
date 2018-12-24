﻿using System.Threading.Tasks;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingAnAsyncCommand : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldBeCalledOnce()
        {
            var command = new TestAsyncCommand();

            await mediator.ExecuteAsync(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
