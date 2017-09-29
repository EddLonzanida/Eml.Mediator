using System;
using Eml.Mef;

namespace Eml.Mediator.Tests.Integration
{
    public class MefFixture : IDisposable
    {
        public MefFixture()
        {
            Bootstrapper.Init();
        }

        public void Dispose()
        {
            Mef.ClassFactory.MefContainer?.Dispose();
        }
    }
}
