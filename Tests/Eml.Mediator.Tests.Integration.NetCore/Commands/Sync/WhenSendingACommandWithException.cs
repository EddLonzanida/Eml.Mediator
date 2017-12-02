using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;using System;using Eml.Mediator.Tests.Common.Commands;using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync
{
    public class WhenSendingACommandWithException : IntegrationTestBase
    {
        [Fact]
        public void Command_ShouldThrowException()
        {
            var command = new TestCommandWithException();

            Should.Throw<NotImplementedException>(() => mediator.Set(command));
        }
    }
}
