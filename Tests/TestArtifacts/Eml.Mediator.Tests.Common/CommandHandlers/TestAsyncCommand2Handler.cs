using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.CommandHandlers;

public class TestAsyncCommand2Handler : ICommandAsyncHandler<TestAsyncCommandWithMultipleHandler>
{
    public async Task ExecuteAsync(TestAsyncCommandWithMultipleHandler commandAsync)
    {
        await Task.Run(() => commandAsync.HandlerInvocationCount++);
    }
}
