using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using System;

namespace Eml.Mediator.Tests.Common.CommandEngines;

public class TestCommandWithExceptionEngine : ICommandEngine<TestCommandWithException>
{
    public void Execute(TestCommandWithException command)
    {
        throw new NotImplementedException();
    }
}
