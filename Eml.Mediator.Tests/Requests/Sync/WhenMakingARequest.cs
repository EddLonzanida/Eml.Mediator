using System;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Requests.Engines;
using Eml.Mediator.Tests.Responses;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequest : IntegrationTestBase
    {
        [Test]
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

        [Test]
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
