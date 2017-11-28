#if NETFULL
using System.ComponentModel.Composition;
#endif
using Eml.Mediator.Contracts;namespace Eml.Mediator.Tests.Common.Commands.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestCommandWithExceptionEngine : ICommandEngine<TestCommandWithException>
    {
        public void Set(TestCommandWithException command)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}