using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async;

public class WhenMakingAsyncRequestWithoutHandler : IntegrationTestDiBase
{
    [Fact]
    public async Task Response_ShouldThrowMissingHandlerException()
    {
        var request = new TestAsyncRequestWithNoHandler(Guid.CreateVersion7());

        await Should.ThrowAsync<MissingHandlerException>(async () => await mediator.ExecuteAsync(request));
    }

    [Fact]
    public async Task Response_ShouldThrowMissingHandlerExceptionWhenRequestIsOpenGenerics()
    {
        var request = new AutoSuggestAsyncRequest<string>("Test");

        await Should.ThrowAsync<MissingHandlerException>(async () => await mediator.ExecuteAsync(request));
    }
}
