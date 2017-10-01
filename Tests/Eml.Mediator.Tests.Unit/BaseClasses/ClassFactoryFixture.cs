using System;
using Eml.Mef;
using Xunit;

namespace Eml.Mediator.Tests.Unit.BaseClasses
{
    public class ClassFactoryFixture : IDisposable
    {
        public  const string CLASS_FIXTURE = "ClassFactory CollectionDefinition";

        public ClassFactoryFixture()
        {
            Bootstrapper.Init();
        }

        public void Dispose()
        {
            Mef.ClassFactory.MefContainer?.Dispose();
        }
    }

    [CollectionDefinition(ClassFactoryFixture.CLASS_FIXTURE)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<ClassFactoryFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
