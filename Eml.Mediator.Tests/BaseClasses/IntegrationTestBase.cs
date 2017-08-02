using Eml.Contracts.Factories;
using Eml.Contracts.Mef;
using NUnit.Framework;

namespace Eml.Mediator.Tests.BaseClasses
{
    public abstract class IntegrationTestBase
    {

        [SetUp]
        public void SetUp()
        {
            MefLoader.Init(typeof(IntegrationTestBase));
        }

        [TearDown]
        public void TearDown()
        {
            ClassFactory.Dispose();
        }
    }
}
