using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync;

public class WhenMakingARequestWithException : IntegrationTestDiBase
{
    [Fact]
    public void Response_ShouldThrowException()
    {
        var request = new TestRequestWithException(Guid.CreateVersion7());

        Should.Throw<NotImplementedException>(() => mediator.Execute(request));
    }
}
