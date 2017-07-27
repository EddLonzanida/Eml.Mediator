using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingAnAsyncRequestWithMultipleEngine : IntegrationTestBase
    {
        [Test]
        public void ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleAsyncEngine(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => request.GetAsync());
        }
    }
}
