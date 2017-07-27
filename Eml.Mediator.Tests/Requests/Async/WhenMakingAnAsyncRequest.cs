using System;
using System.Threading.Tasks;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Async
{
    [TestFixture]
    public class WhenMakingAnAsyncRequest: IntegrationTestBase
    {
        [Test]
        public async Task TheRequestEngineShouldReturnACorrectResponseType()
        {
            var request = new TestRequestAsync(Guid.NewGuid());

            var response = await request.GetAsync();

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Test]
        public async Task TheRequestAndResponseIdsShouldMatch()
        {
            var request = new TestRequestAsync(Guid.NewGuid());

            var response = await request.GetAsync();

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
