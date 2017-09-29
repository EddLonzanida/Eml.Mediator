using Eml.Mediator.Contracts;
using Xunit;

namespace Eml.Mediator.Tests.Unit.BaseClasses
{
    [Collection(ClassFactoryFixture.CLASS_FIXTURE)]
    public abstract class UnitTestBase
    {
        protected readonly IMediator mediator;
        protected UnitTestBase()
        {
#if NETFULL
            mediator = Mef.ClassFactory.MefContainer.GetExportedValue<IMediator>();
#endif
#if NETCORE
            mediator = Mef.ClassFactory.MefContainer.GetExport<IMediator>();
#endif
        }

   
    }
}
