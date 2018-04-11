using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mef;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Integration.BaseClasses
{
    public abstract class UnitTestBase
    {
        protected IMediator mediator;

        private IClassFactory classFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            classFactory = Bootstrapper.Init();

            mediator = classFactory.GetExport<IMediator>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var container = classFactory.Container;

            container?.Dispose();
        }
    }
}
