﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithoutEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldThrowMissingEngineException()
        {
            var command = new TestAsyncCommandWithNoEngine();

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}