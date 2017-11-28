using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Commands;
using Eml.Mediator.Tests.Unit.Requests;
using Eml.Mediator.Tests.Unit.Responses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration
{
    public class WhenExecutingTestEngines : IClassFixture<MefFixture>
    {
        private readonly IClassFactory classFactory;

        public WhenExecutingTestEngines()
        {
             classFactory =  Mef.ClassFactory.Get();
        }

        [Fact]
        public void TestRequestEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestEngine<TestRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestRequestAsyncEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TestAsyncRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ICommandEngine<TestCommand>>();
            exported.ShouldNotBeNull();
        }

        [Fact]
        public void TestAsyncCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ICommandAsyncEngine<TestAsyncCommand>>();
            exported.ShouldNotBeNull();
        }
    }
}
