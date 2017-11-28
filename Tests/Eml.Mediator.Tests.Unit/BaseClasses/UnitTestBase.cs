using Eml.Mediator.Contracts;
using Xunit;

namespace Eml.Mediator.Tests.Unit.BaseClasses
{
    [Collection(MefFixture.COLLECTION_DEFINITION)]
    public abstract class UnitTestBase
    {
        protected readonly IMediator mediator;

        protected UnitTestBase()
        {
            var classFactory =  Mef.ClassFactory.Get();
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
