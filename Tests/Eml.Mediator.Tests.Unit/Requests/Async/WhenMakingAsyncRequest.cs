using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Responses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    public class WhenMakingAsyncRequest: UnitTestBase
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
