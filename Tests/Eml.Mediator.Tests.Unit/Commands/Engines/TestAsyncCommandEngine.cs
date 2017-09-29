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
    public class TestAsyncCommandEngine : ICommandAsyncEngine<TestAsyncCommand>
    {
        public async Task SetAsync(TestAsyncCommand commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }

        public void Dispose()
        {
        }
    }
}
