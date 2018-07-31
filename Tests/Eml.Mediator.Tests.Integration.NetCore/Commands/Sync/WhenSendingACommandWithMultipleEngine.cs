﻿using Eml.Mediator.Exceptions;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Sync
{
    public class WhenSendingACommandWithMultipleEngine : IntegrationTestDiBase
    {
        [Fact]
        public void Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleEngine();

            Should.Throw<MultipleEngineException>(() => mediator.Set(command));
        }
    }
}