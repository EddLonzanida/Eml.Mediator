using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequestWithoutEngine : IntegrationTestBase
    {
        [Test]
        public void Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestRequestWithNoEngine(Guid.NewGuid());

            Should.Throw<MissingEngineException>(() => mediator.Get(request));
        }
    }
}
