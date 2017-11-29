using System.Threading.Tasks;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithoutEngine : IntegrationTestBase
    {
        [Fact]
        public async Task Command_ShouldThrowMissingEngineException()
        {
            var command = new TestAsyncCommandWithNoEngine();

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}
