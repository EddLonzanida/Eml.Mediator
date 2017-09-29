using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
{
    public class WhenSendingAnAsyncCommandThatThrowsException : UnitTestBase
    {
        [Fact]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestAsyncCommandWithException();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.SetAsync(command));
        }
    }
}
