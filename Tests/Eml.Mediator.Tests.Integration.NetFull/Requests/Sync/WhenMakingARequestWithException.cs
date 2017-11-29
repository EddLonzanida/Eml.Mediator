using System;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Sync
{
    public class WhenMakingARequestWithException : IntegrationTestBase
    {
        [Fact]
        public void Response_ShouldThrowException()
        {
            var request = new TestRequestWithException(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => mediator.Get(request));
        }
    }
}
