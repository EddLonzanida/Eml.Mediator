using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync;

public class WhenSendingACommandWithoutHandler : IntegrationTestDiBase
{
    [Fact]
    public void Command_ShouldThrowMissingHandlerException()
    {
        var command = new TestCommandWithNoHandler();

        Should.Throw<MissingHandlerException>(() => mediator.Execute(command));
    }
}
