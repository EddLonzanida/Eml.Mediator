﻿using System;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithException : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestWithExceptionAsyncCommand();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.SetAsync(command));
        }
    }
}