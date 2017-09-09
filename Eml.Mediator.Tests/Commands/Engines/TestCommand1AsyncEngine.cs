using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommand1AsyncEngine : ICommandAsyncEngine<TestCommandWithMultipleAsyncEngine>
    {
        public async Task SetAsync(TestCommandWithMultipleAsyncEngine commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }

        public void Dispose()
        {
        }
    }
}