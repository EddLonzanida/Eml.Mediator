#if NETFULL
using System.ComponentModel.Composition;
#endif
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
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