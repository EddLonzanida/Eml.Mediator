using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestWithExceptionAsyncCommandEngine : ICommandAsyncEngine<TestWithExceptionAsyncCommand>
    {
        public Task SetAsync(TestWithExceptionAsyncCommand commandAsync)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
