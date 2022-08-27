using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Commands.Async;

public class WhenSendingAnAsyncCommandThatThrowsException : IntegrationTestDiBase
{
    [Fact]
    public async Task Command_ShouldThrowException()
    {
        var command = new TestAsyncCommandWithException();

        await Should.ThrowAsync<NotImplementedException>(async () => await mediator.ExecuteAsync(command));
    }
}
