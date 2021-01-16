using System;using System.Threading.Tasks;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class WhenMakingAsyncRequestWithoutEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Response_ShouldThrowMissingEngineException()
        {
            var request = new TestAsyncRequestWithNoEngine(Guid.NewGuid());

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.ExecuteAsync(request));
        }

        [Fact]
        public async Task Response_ShouldThrowMissingEngineExceptionWhenRequestIsOpenGenerics()
        {
            var request = new AutoSuggestAsyncRequest<string>("Test");

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.ExecuteAsync(request));
        }
    }
}
