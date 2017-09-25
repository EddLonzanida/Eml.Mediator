using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithoutEngine : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldThrowMissingEngineException()
        {
            var command = new TestAsyncCommandWithNoEngine();

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}
