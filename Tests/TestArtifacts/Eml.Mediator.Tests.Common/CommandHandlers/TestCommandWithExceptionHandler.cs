using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using System;

namespace Eml.Mediator.Tests.Common.CommandHandlers;

public class TestCommandWithExceptionHandler : ICommandHandler<TestCommandWithException>
{
    public void Execute(TestCommandWithException command)
    {
        throw new NotImplementedException();
    }
}
