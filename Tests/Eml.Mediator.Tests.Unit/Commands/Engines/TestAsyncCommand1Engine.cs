#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using Eml.Mediator.Contracts;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Unit.Commands.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
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