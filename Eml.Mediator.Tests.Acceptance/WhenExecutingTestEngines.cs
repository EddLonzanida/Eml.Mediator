using System.Collections.Generic;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Commands;
using Eml.Mediator.Tests.Unit.Requests;
using Eml.Mediator.Tests.Unit.Responses;
using Eml.MefBootstrapper;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Acceptance
{
    [TestFixture]
    public class WhenExecutingAccountingPipeline
    {
        [SetUp]
        public void Setup()
        {
            MefLoader.Init();
        }

        [Test]
        public void TestRequestEngine_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IRequestEngine<TestRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestRequestAsyncEngine_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IRequestAsyncEngine<TestAsyncRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestCommand_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<ICommandEngine<TestCommand>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestAsyncCommand_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<ICommandAsyncEngine<TestAsyncCommand>>();
            exported.ShouldNotBeNull();
        }

        [TearDown]
        public void TearDown()
        {
            MefBootstrapper.ClassFactory.Mef?.Dispose();
        }
    }
}
