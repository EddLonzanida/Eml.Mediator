using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithoutEngine : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldThrowMissingEngineException()
        {
            var command = new TestWithNoEngineAsyncCommand();

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.SetAsync(command));
        }
    }
}
