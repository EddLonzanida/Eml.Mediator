﻿using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingAnAsyncCommandThatThrowsException : IntegrationTestBase
    {
        [Fact]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestAsyncCommandWithException();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.SetAsync(command));
        }
    }
}
