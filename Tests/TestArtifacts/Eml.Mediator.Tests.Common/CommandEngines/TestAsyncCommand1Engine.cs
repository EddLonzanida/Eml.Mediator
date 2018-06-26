using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestAsyncCommand1Engine : ICommandAsyncEngine<TestWithMultipleEngineAsyncCommand>
    {
        public async Task SetAsync(TestWithMultipleEngineAsyncCommand commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }

        public void Dispose()
        {
        }
    }
}