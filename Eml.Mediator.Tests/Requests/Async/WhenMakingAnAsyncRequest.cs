using System;
using System.Threading.Tasks;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Responses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Async
{
    [TestFixture]
    public class WhenMakingAnAsyncRequest: IntegrationTestBase
    {
        [Test]
        public async Task Response_ShouldBeCorrectType()
        {
            var request = new TestRequestAsync(Guid.NewGuid());

            var response = await request.GetAsync();

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Test]
        public async Task Response_ShouldReturnCorrectValue()
        {
            var request = new TestRequestAsync(Guid.NewGuid());

            var response = await request.GetAsync();

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
