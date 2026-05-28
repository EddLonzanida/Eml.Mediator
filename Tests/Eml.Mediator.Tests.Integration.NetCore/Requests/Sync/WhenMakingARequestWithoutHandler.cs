using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync;

public class WhenMakingARequestWithoutHandler : IntegrationTestDiBase
{
    [Fact]
    public void Response_ShouldThrowAMissingHandlerException()
    {
        var request = new TestRequestWithNoHandler(Guid.CreateVersion7());

        Should.Throw<MissingHandlerException>(() => mediator.Execute(request));
    }
}
