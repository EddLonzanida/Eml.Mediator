using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Commands.Engines
{
    public class TestCommandAsyncEngine : ICommandAsyncEngine<TestCommandAsync>
    {
        public async Task SetAsync(TestCommandAsync commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }
    }
}
