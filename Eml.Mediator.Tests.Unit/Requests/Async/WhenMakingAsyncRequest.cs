using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Responses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    [TestFixture]
    public class WhenMakingAsyncRequest: UnitTestBase
    {
        [Test]
        public async Task Response_ShouldBeCorrectType()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());

            var response = await mediator.GetAsync(request);

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Test]
        public async Task Response_ShouldReturnCorrectValue()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());

            var response = await mediator.GetAsync(request);

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
