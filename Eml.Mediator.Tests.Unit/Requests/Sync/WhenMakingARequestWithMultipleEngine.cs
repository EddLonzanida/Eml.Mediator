using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Requests.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequestWithMultipleEngine : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleEngine(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => mediator.Get(request));
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequest1Engine>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<TestRequest2Engine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
