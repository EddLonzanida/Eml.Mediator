#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands.Engines
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