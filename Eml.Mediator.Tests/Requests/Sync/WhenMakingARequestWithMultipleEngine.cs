using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Requests.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequestWithMultipleEngine : IntegrationTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleEngine(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => request.Get());
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequest1Engine>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<TestRequest2Engine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
