using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommand2AsyncEngine : ICommandAsyncEngine<TestCommandWithMultipleAsyncEngine>
    {
        public async Task SetAsync(TestCommandWithMultipleAsyncEngine commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }
    }
}