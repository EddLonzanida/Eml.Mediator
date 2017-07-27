using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Async
{
    [TestFixture]
    public class WhenSendingACommandWithMultipleAsyncEngine : IntegrationTestBase
    {
        [Test]
        public async Task ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleAsyncEngine();

            await Should.ThrowAsync<MultipleEngineException>(async () => await command.SetAsync());
        }
    }
}