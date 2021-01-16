using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    public class TestAsyncCommandEngine : ICommandAsyncEngine<TestAsyncCommand>
    {
        public async Task ExecuteAsync(TestAsyncCommand commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }

        public void Dispose()
        {
        }
    }
}
