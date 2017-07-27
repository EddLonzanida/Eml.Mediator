using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithoutEngine : IntegrationTestBase
    {
        [Test]
        public async Task ShouldThrowMissingEngineException()
        {
            var command = new TestCommandWithNoAsyncEngine();

            await Should.ThrowAsync<MissingEngineException>(async () => await command.SetAsync());
        }
    }
}
