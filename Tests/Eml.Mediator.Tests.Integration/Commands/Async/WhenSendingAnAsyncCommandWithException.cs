using System;using System.Threading.Tasks;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.BaseClasses;using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithException : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestWithExceptionAsyncCommand();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.ExecuteAsync(command));
        }
    }
}
