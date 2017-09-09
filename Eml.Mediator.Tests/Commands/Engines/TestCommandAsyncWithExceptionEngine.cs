using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommandAsyncWithExceptionEngine : ICommandAsyncEngine<TestCommandAsyncWithException>
    {
        public Task SetAsync(TestCommandAsyncWithException commandAsync)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
