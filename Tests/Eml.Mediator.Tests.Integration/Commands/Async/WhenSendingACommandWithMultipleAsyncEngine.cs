using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingACommandWithMultipleAsyncEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestWithMultipleEngineAsyncCommand();

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.ExecuteAsync(command));
        }
    }
}