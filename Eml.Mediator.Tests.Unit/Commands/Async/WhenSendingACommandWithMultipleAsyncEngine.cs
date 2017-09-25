using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
{
    [TestFixture]
    public class WhenSendingACommandWithMultipleAsyncEngine : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestAsyncCommandWithMultipleEngine();

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}