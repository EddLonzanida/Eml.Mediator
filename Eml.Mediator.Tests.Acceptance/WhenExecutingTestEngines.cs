using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Commands;
using Eml.Mediator.Tests.Unit.Requests;
using Eml.Mediator.Tests.Unit.Responses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Acceptance
{
    [TestFixture]
    public class WhenExecutingAccountingPipeline : IDisposable
    {
        [SetUp]
        public void Setup()
        {
            Mef.Bootstrapper.Init();
        }

        [Test]
        public void TestRequestEngine_ShouldBeDiscoverable()
        {
            var exported = Mef.ClassFactory.MefContainer.GetExportedValue<IRequestEngine<TestRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestRequestAsyncEngine_ShouldBeDiscoverable()
        {
            var exported = Mef.ClassFactory.MefContainer.GetExportedValue<IRequestAsyncEngine<TestAsyncRequest, TestResponse>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestCommand_ShouldBeDiscoverable()
        {
            var exported = Mef.ClassFactory.MefContainer.GetExportedValue<ICommandEngine<TestCommand>>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void TestAsyncCommand_ShouldBeDiscoverable()
        {
            var exported = Mef.ClassFactory.MefContainer.GetExportedValue<ICommandAsyncEngine<TestAsyncCommand>>();
            exported.ShouldNotBeNull();
        }

        public void Dispose()
        {
            Mef.ClassFactory.MefContainer?.Dispose();
        }
    }
}
