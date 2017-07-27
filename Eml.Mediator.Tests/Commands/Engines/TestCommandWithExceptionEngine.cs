using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommandWithExceptionEngine : ICommandEngine<TestCommandWithException>
    {
        public void Set(TestCommandWithException command)
        {
            throw new System.NotImplementedException();
        }
    }
}