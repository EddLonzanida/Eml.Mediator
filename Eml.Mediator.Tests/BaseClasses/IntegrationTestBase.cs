using Eml.MefBootstrapper;
using NUnit.Framework;

namespace Eml.Mediator.Tests.BaseClasses
{
    public abstract class IntegrationTestBase
    {

        [SetUp]
        public void SetUp()
        {
            MefLoader.Init(new[]{"Eml*.dll"});
        }
    }
}
