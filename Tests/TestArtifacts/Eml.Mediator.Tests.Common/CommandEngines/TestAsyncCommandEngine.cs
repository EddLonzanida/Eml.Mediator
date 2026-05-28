using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.CommandHandlers;

/// <summary>
///     DI signature: ICommandAsyncHandler&lt;TestAsyncCommand&gt;.
///     <inheritdoc cref="ICommandAsyncHandler{TestAsyncCommand}" />
/// </summary>
public class TestAsyncCommandHandler : ICommandAsyncHandler<TestAsyncCommand>
{
    public async Task ExecuteAsync(TestAsyncCommand commandAsync)
    {
        await Task.Run(() => commandAsync.HandlerInvocationCount++);
    }
}
