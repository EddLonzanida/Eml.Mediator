using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync;

public class WhenSendingACommandWithException : IntegrationTestDiBase
{
    [Fact]
    public void Command_ShouldThrowException()
    {
        var command = new TestCommandWithException();

        Should.Throw<NotImplementedException>(() => mediator.Execute(command));
    }
}
