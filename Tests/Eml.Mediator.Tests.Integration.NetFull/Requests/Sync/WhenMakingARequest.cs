using System;
using Eml.Mediator.Tests.Common.RequestEngines;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;
using JetBrains.dotMemoryUnit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Sync
{
    public class WhenMakingARequest : IntegrationTestBase
    {
        [Fact]
        //[DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldBeCorrectType()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = mediator.Get(request);

            response.ShouldBeOfType(typeof(TestResponse));
            //using (DotMemoryUnit.Support())
            //{

            //    dotMemory.Check(memory =>
            //    {
            //        memory.GetObjects(where => where.Type.Is<TestRequestEngine>()).ObjectsCount.ShouldBe(0);
            //    });

            //}
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
