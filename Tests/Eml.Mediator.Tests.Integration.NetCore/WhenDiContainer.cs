using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        [Fact]
        public void TestRequestEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetRequiredService<IRequestEngine<TestRequest, TestResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestRequestAsyncEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetRequiredService<IRequestAsyncEngine<TestAsyncRequest, TestResponse>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetRequiredService<ICommandEngine<TestCommand>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestAsyncCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetRequiredService<ICommandAsyncEngine<TestAsyncCommand>>();

            exported.ShouldNotBeNull();
        }

        [Fact]
        public void UserIdCacheAsyncEngine_ShouldBeDiscoverable()
        {
            var export = classFactory.GetRequiredService<IRequestAsyncEngine<UserIdCacheAsyncRequest<int>, UserIdCacheResponse<int>>>();

            export.ShouldNotBeNull();
        }
    }
}
