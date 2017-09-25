using Eml.Mediator.Contracts;
using Eml.MefBootstrapper;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Unit.BaseClasses
{
    public abstract class UnitTestBase
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
