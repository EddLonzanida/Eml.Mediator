using System;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Commands.Sync
{
    public class WhenSendingACommandThatThrowsException : IntegrationTestBase
    {
        [Fact]
        public void Command_ShouldThrowException()
        {
            var command = new TestCommandWithException();

            Should.Throw<NotImplementedException>(() => mediator.Set(command));
        }
    }
}
