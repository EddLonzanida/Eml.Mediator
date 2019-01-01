using System;using Eml.Mediator.Exceptions;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.BaseClasses;using Xunit;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Sync
{
    public class WhenMakingARequestWithoutEngine : IntegrationTestDiBase
    {
        [Fact]
        public void Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestWithNoEngineRequest(Guid.NewGuid());

            Should.Throw<MissingEngineException>(() => mediator.Get(request));
        }
    }
}
