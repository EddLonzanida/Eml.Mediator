using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
{
    public class WhenSendingACommandWithMultipleAsyncEngine : UnitTestBase
    {
        [Fact]
        public async Task Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestAsyncCommandWithMultipleEngine();

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}