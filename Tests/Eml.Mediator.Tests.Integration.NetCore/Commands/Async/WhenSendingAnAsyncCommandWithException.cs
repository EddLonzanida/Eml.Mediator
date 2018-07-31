﻿using System;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingAnAsyncCommandThatThrowsException : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestAsyncCommandWithException();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.SetAsync(command));
        }
    }
}