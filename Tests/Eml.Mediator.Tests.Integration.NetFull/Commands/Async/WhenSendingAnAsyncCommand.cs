﻿using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Commands.Async
{
    public class WhenSendingAnAsyncCommand : IntegrationTestBase
    {
        [Fact]
        public async Task Command_ShouldBeCalledOnce()
        {
            var command = new TestAsyncCommand();

            await mediator.SetAsync(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
