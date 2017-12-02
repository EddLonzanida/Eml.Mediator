using System;using Eml.Mediator.Tests.Common.RequestEngines;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using JetBrains.dotMemoryUnit;using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Sync
{
    public class WhenMakingARequestWithException : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldThrowException()
        {
            var request = new TestRequestWithException(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => mediator.Get(request));

            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequestWithExceptionEngine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
