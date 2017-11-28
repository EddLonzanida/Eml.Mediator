using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Eml.Mediator.Tests.Integration.NetCore.Responses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class WhenMakingAsyncRequest: IntegrationTestBase
    {
        [Fact]
        public async Task Response_ShouldBeCorrectType()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());

            var response = await mediator.GetAsync(request);

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Fact]
        public async Task Response_ShouldReturnCorrectValue()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());

            var response = await mediator.GetAsync(request);

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
