using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommandAsyncWithExceptionEngine : ICommandAsyncEngine<TestCommandAsyncWithException>
    {
        public Task SetAsync(TestCommandAsyncWithException commandAsync)
        {
            throw new NotImplementedException();
        }
    }
}
