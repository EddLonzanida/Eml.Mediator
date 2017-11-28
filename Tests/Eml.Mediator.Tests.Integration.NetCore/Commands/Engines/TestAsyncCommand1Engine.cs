using Eml.ClassFactory.Contracts;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Engines
{
    public class TestAsyncCommand1Engine : ICommandAsyncEngine<TestAsyncCommandWithMultipleEngine>
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