using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync;

public class WhenMakingARequestWithMultipleHandler : IntegrationTestDiBase
{
    [Fact]
    public void Response_ShouldThrowMultipleHandlerException()
    {
        var request = new TestRequestWithMultipleHandler(Guid.CreateVersion7());

        Should.Throw<MultipleHandlerException>(() => mediator.Execute(request));
    }
}
