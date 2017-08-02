using System;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using Eml.Mediator.Tests.Requests.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequestThatThrowsException : IntegrationTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void ShouldThrowException()
        {
            var request = new TestRequestWithException(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => request.Get());
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestRequestWithExceptionEngine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
