using System;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Sync
{
    [TestFixture]
    public class WhenMakingARequestThatThrowsException : IntegrationTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            var request = new TestRequestWithException(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => request.Get());
        }
    }
}
