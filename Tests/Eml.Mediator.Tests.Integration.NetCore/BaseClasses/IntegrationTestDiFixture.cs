using System;
using Eml.ClassFactory.Contracts;
using Eml.Mef;using Xunit;namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public  const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDiFixture()
        {
            ClassFactory = Bootstrapper.Init();
        }

        public void Dispose()
        {
            ClassFactory.Dispose();
        }
    }

    [CollectionDefinition(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
