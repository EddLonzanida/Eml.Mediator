using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.BaseClasses;
using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Async
{
    public class WhenMakingAsyncRequestWithException : IntegrationTestDiBase
    {
        [Fact]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestWithExceptionAsyncRequest(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.GetAsync(request));
        }
    }
}
