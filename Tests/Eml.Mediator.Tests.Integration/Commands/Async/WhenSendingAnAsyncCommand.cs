using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommand : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldBeCalledOnce()
        {
            var command = new TestAsyncCommand();

            await mediator.SetAsync(command);

            command.EngineInvocationCount.ShouldBe(1);
        }
    }
}
