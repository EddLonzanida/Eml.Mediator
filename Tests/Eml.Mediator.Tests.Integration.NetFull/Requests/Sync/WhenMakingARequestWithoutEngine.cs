using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Sync
{
    public class WhenMakingARequestWithoutEngine : IntegrationTestBase
    {
        [Fact]
        public void Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestRequestWithNoEngine(Guid.NewGuid());

            Should.Throw<MissingEngineException>(() => mediator.Get(request));
        }
    }
}
