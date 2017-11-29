using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Commands.Async
{
    public class WhenSendingACommandWithMultipleAsyncEngine : IntegrationTestBase
    {
        [Fact]
        public async Task Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestAsyncCommandWithMultipleEngine();

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}