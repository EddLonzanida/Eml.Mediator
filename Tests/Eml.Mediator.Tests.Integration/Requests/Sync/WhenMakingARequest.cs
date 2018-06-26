using System;using Eml.Mediator.Tests.Common.RequestEngines;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Common.Responses;using Eml.Mediator.Tests.Integration.BaseClasses;using JetBrains.dotMemoryUnit;using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Sync
{
    public class WhenMakingARequest : IntegrationTestDiBase
    {
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldBeCorrectType()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = mediator.Get(request);

            response.ShouldBeOfType(typeof(TestResponse));
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequestEngine>()).ObjectsCount.ShouldBe(0);
            });
        }

        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldBeCorrectValue()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = mediator.Get(request);

            response.ResponseToRequestId.ShouldBe(request.Id);
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequestEngine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
