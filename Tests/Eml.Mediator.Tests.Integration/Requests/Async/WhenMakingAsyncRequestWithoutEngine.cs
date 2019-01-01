using System;using System.Threading.Tasks;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Async
{
    public class WhenMakingAsyncRequestWithoutEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Response_ShouldThrowMissingEngineException()
        {
            var request = new TestWithNoEngineAsyncRequest(Guid.NewGuid());

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }

        [Fact]
        public async Task Response_ShouldThrowMissingEngineExceptionWhenRequestIsOpenGenerics()
        {
            var request = new AutoSuggestAsyncRequest<string>("Test");

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
