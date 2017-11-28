using Eml.Mediator.Contracts;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses
{
    [Collection(MefFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase
    {
        protected readonly IMediator mediator;

        protected IntegrationTestBase()
        {
            var classFactory =  Mef.ClassFactory.Get();
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
