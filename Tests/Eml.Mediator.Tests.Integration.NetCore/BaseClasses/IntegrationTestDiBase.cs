using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDiBase
    {
        protected readonly IMediator mediator;

        protected readonly IClassFactory classFactory;

        protected IntegrationTestDiBase()
        {
            classFactory = IntegrationTestDiFixture.ClassFactory;
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
