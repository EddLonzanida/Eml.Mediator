using Eml.Mediator.Contracts;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Unit.BaseClasses
{
    public abstract class UnitTestBase
    {
        protected IMediator mediator;

        [SetUp]
        public void SetUp()
        {
            Mef.Bootstrapper.Init();
            mediator = Mef.ClassFactory.MefContainer.GetExportedValue<IMediator>();
        }
    }
}
