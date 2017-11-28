#if NETFULLusing System.ComponentModel.Composition;#endifusing System.Threading.Tasks;using Eml.Mediator.Contracts;namespace Eml.Mediator.Tests.Common.Commands.Engines
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
