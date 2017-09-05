using System;
using System.Threading.Tasks;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Async
{
    public class WhenSendingAnAsyncCommandThatThrowsException : IntegrationTestBase
    {
        [Test]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestCommandAsyncWithException();

            await Should.ThrowAsync<NotImplementedException>(async () => await command.SetAsync());
        }
    }
}
