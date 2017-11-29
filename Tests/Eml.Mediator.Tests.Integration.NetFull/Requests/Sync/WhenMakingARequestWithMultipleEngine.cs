using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Sync
{
    public class WhenMakingARequestWithMultipleEngine : IntegrationTestBase
    {
        [Fact]
        public void Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleEngine(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => mediator.Get(request));
        }
    }
}
