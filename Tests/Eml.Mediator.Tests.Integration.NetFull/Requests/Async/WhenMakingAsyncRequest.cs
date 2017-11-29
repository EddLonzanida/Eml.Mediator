using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Async
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
