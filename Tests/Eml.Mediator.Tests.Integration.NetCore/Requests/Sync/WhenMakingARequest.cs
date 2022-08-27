using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync;

public class WhenMakingARequest : IntegrationTestDiBase
{
    [Fact]
    public void Response_ShouldBeCorrectType()
    {
        var request = new TestRequest(Guid.NewGuid());

        var response = mediator.Execute(request);

        response.ShouldBeOfType(typeof(TestResponse));
    }

    [Fact]
    public void Response_ShouldBeCorrectValue()
    {
        var request = new TestRequest(Guid.NewGuid());

        var response = mediator.Execute(request);

        response.ResponseToRequestId.ShouldBe(request.Id);
    }
}
