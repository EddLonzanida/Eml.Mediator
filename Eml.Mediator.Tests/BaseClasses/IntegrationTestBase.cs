using Eml.Mediator.Contracts;
using Eml.MefBootstrapper;
using NUnit.Framework;

namespace Eml.Mediator.Tests.BaseClasses
{
    public abstract class IntegrationTestBase
    {
        protected IMediator mediator;

        [SetUp]
        public void SetUp()
        {
            MefLoader.Init();
            mediator = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IMediator>();
        }
    }
}
