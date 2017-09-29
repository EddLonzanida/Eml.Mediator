using System;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Responses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Sync
{
    public class WhenMakingARequest : UnitTestBase
    {
        [Fact]
        public void Response_ShouldBeCorrectType()
        {
           var request = new TestRequest(Guid.NewGuid());
            
           var response = mediator.Get(request);

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Fact]
        public void Response_ShouldBeCorrectValue()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = mediator.Get(request);

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}
