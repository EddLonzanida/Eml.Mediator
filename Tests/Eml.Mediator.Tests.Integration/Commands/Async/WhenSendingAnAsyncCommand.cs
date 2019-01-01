using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommand : IntegrationTestDiBase
    {
        [Fact]
        public async Task Command_ShouldBeCalledOnce()
        {
            var command = new TestAsyncCommand();

            await mediator.ExecuteAsync(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
