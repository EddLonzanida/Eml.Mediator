using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    public class TestAsyncCommandWithExceptionEngine : ICommandAsyncEngine<TestAsyncCommandWithException>
    {
        public Task ExecuteAsync(TestAsyncCommandWithException commandAsync)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
