using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    public class TestAsyncCommand1Engine : ICommandAsyncEngine<TestAsyncCommandWithMultipleEngine>
    {
        public async Task ExecuteAsync(TestAsyncCommandWithMultipleEngine commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }
    }
}