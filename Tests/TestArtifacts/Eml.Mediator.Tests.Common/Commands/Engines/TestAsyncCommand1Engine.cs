#if NETFULLusing System.ComponentModel.Composition;#endifusing System.Threading.Tasks;using Eml.Mediator.Contracts;namespace Eml.Mediator.Tests.Common.Commands.Engines
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