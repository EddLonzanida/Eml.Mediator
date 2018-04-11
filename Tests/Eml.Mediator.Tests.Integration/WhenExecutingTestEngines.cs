using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mef;
using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration
{
    [TestFixture]
    public class WhenExecutingTestEngines
    {
        private IClassFactory classFactory;

        [OneTimeSetUp]
        public void Setup()
        {
            classFactory = Bootstrapper.Init();
        }

        [Test]
        public void TestRequestEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestEngine<TestRequest, TestResponse>>();

            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestRequestAsyncEngine_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IRequestAsyncEngine<TestAsyncRequest, TestResponse>>();

            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ICommandEngine<TestCommand>>();

            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestAsyncCommand_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<ICommandAsyncEngine<TestAsyncCommand>>();

            exported.ShouldNotBeNull();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var container = classFactory.Container;

            container?.Dispose();
        }
    }
}