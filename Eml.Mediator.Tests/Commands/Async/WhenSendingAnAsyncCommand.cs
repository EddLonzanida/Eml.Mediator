﻿using System.Threading.Tasks;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Async
{
    public class WhenSendingAnAsyncCommand : IntegrationTestBase
    {
        [Test]
        public async Task TheCommandEngineShouldHaveBeenCalledExactlyOnce()
        {
            var command = new TestCommandAsync();

            await command.SetAsync();

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
