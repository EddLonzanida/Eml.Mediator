using System;using System.Threading.Tasks;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Async
{
    public class WhenMakingAsyncRequestWithMultipleEngine : IntegrationTestDiBase
    {
        [Fact]
        public async Task Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestWithMultipleEngineAsyncRequest(Guid.NewGuid());

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
