using System;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.RequestEngines;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using JetBrains.dotMemoryUnit;using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Sync
{
    public class WhenMakingARequestWithMultipleEngine : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestWithMultipleEngineRequest(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => mediator.Get(request));

            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequest1Engine>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<TestRequest2Engine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
