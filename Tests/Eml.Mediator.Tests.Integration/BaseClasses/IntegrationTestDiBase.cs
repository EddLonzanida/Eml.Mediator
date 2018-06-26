using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Xunit;

namespace Eml.Mediator.Tests.Integration.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDiBase
    {
        protected readonly IClassFactory classFactory;

        protected IMediator mediator;

        protected IntegrationTestDiBase()
        {
            classFactory = IntegrationTestDiFixture.ClassFactory;
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
