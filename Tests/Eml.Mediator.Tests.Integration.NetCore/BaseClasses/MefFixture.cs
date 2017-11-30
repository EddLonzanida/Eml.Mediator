using System;using Eml.Mef;using Xunit;namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public  const string COLLECTION_DEFINITION = "MefFixtureNetCore CollectionDefinition";

        public MefFixture()
        {
            Bootstrapper.Init();
        }

        public void Dispose()
        {
            Mef.ClassFactory.Dispose();
        }
    }

    [CollectionDefinition(MefFixture.COLLECTION_DEFINITION)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<MefFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
