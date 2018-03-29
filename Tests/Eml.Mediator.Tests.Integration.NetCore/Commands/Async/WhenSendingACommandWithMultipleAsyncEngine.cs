using System.Threading.Tasks;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Commands;using Shouldly;
using Xunit;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingACommandWithMultipleAsyncEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestAsyncCommandWithMultipleEngine();

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}