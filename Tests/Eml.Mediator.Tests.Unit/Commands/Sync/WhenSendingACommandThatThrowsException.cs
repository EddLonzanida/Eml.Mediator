using System;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    public class WhenSendingACommandThatThrowsException : UnitTestBase
    {
        [Fact]
        public void Command_ShouldThrowException()
        {
            var command = new TestCommandWithException();

            Should.Throw<NotImplementedException>(() => mediator.Set(command));
        }
    }
}
