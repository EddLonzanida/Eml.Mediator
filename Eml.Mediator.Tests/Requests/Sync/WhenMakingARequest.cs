using System;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequest : IntegrationTestBase
    {
        [Test]
        public void TheRequestEngineShouldReturnACorrectResponseType()
        {
           var request = new TestRequest(Guid.NewGuid());
            
           var response = request.Get();

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Test]
        public void TheRequestAndResponseIdsShouldMatch()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = request.Get();

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
