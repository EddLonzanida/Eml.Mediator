using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async;

public class WhenSendingAnAsyncCommandWithoutHandler : IntegrationTestDiBase
{
    [Fact]
    public async Task Command_ShouldThrowMissingHandlerException()
    {
        var command = new TestAsyncCommandWithNoHandler();

        await Should.ThrowAsync<MissingHandlerException>(async () => await mediator.ExecuteAsync(command));
    }
}
