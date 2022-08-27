using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.CommandEngines;

/// <summary>
///     DI signature: ICommandAsyncEngine&lt;TestAsyncCommand&gt;.
///     <inheritdoc cref="ICommandAsyncEngine{TestAsyncCommand}" />
/// </summary>
public class TestAsyncCommandEngine : ICommandAsyncEngine<TestAsyncCommand>
{
    public async Task ExecuteAsync(TestAsyncCommand commandAsync)
    {
        await Task.Run(() => commandAsync.EngineInvocationCount++);
    }
}
