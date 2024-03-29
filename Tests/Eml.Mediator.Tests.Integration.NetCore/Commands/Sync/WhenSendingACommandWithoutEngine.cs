﻿using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync;

public class WhenSendingACommandWithoutEngine : IntegrationTestDiBase
{
    [Fact]
    public void Command_ShouldThrowMissingEngineException()
    {
        var command = new TestCommandWithNoEngine();

        Should.Throw<MissingEngineException>(() => mediator.Execute(command));
    }
}
