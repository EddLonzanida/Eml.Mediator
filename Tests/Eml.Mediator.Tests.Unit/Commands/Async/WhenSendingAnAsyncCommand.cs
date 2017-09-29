using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
{
    public class WhenSendingAnAsyncCommand : UnitTestBase
    {
        [Fact]
        public async Task Command_ShouldBeCalledOnce()
        {
            var command = new TestAsyncCommand();

            await mediator.SetAsync(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
