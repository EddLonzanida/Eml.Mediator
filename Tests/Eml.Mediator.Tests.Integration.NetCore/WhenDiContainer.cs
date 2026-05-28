using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Eml.Mediator.Tests.Integration.NetCore.Requests.Async;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore;

public class WhenDiContainer : IntegrationTestDiBase
{
    [Fact]
    public void TestRequestHandler_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<IRequestHandler<TestRequest, TestResponse>>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void TestRequestAsyncHandler_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<IRequestAsyncHandler<TestAsyncRequest, TestResponse>>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void TestCommand_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<ICommandHandler<TestCommand>>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void TestAsyncCommand_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<ICommandAsyncHandler<TestAsyncCommand>>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void UserIdCacheAsyncHandler_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<IRequestAsyncHandler<UserIdCacheAsyncRequest<int>, UserIdCacheResponse<int>>>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void ConsumerClassWithMediator_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<IConsumerClassWithMediator>();

        exported.ShouldNotBeNull();
    }

    [Fact]
    public void CConsumerClassWithoutMediator_ShouldBeDiscoverable()
    {
        var exported = classFactory.GetRequiredService<IConsumerClassWithoutMediator>();

        exported.ShouldNotBeNull();
    }
}
