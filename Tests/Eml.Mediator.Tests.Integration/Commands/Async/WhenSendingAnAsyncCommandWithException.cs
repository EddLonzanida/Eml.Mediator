using System;using System.Threading.Tasks;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.BaseClasses;using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Async
{
    public class WhenSendingAnAsyncCommandWithException : UnitTestBase
    {
        [Test]
        public async Task Command_ShouldThrowException()
        {
            var command = new TestWithExceptionAsyncCommand();

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.SetAsync(command));
        }
    }
}
