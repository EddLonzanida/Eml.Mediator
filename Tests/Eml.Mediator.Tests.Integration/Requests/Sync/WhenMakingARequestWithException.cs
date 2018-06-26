using System;using Eml.Mediator.Tests.Common.RequestEngines;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using JetBrains.dotMemoryUnit;using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Sync
{
    public class WhenMakingARequestWithException : IntegrationTestDiBase
    {
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldThrowException()
        {
            var request = new TestWithExceptionRequest(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => mediator.Get(request));

            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequestWithExceptionEngine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
