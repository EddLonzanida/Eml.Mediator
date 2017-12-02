using Eml.Mediator.Contracts;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Integration.BaseClasses
{
    public abstract class UnitTestBase
    {
        protected IMediator mediator;

        [OneTimeSetUp]
        public void SetUp()
        {
            Mef.Bootstrapper.Init();
            var classFactory = Mef.ClassFactory.Get();
            mediator = classFactory.GetExport<IMediator>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Mef.ClassFactory.Dispose();
        }
    }
}
