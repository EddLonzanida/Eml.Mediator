using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async;

public class WhenSendingACommandWithMultipleAsyncHandler : IntegrationTestDiBase
{
    [Fact]
    public async Task Command_ShouldThrowMultipleHandlerException()
    {
        var command = new TestAsyncCommandWithMultipleHandler();

        await Should.ThrowAsync<MultipleHandlerException>(async () => await mediator.ExecuteAsync(command));
    }
}
