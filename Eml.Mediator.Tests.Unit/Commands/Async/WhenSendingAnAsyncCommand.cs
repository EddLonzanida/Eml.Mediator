using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Async
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
