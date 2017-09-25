using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Commands.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestAsyncCommand2Engine : ICommandAsyncEngine<TestAsyncCommandWithMultipleEngine>
    {
        public async Task SetAsync(TestAsyncCommandWithMultipleEngine commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }

        public void Dispose()
        {
        }
    }
}