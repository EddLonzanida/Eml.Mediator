using Eml.ClassFactory.Contracts;using Eml.Mediator.Contracts;using Xunit;namespace Eml.Mediator.Tests.Integration.NetFull.BaseClasses
{
    [Collection(MefFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase
    {
        protected readonly IMediator mediator;
        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase()
        {
            classFactory = Mef.ClassFactory.Get();
            mediator = classFactory.GetExport<IMediator>();
        }
    }
}
