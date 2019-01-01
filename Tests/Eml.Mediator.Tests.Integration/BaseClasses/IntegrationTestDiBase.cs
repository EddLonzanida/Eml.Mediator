using Eml.ClassFactory.Contracts;
using Eml.Mediator.Contracts;
using Eml.Mef;
using System;

namespace Eml.Mediator.Tests.Integration.BaseClasses
{
    public abstract class IntegrationTestDiBase : IDisposable
    {
        protected readonly IClassFactory classFactory;

        protected IMediator mediator;

        protected IntegrationTestDiBase()
        {
            classFactory = Bootstrapper.Init();
            mediator = classFactory.GetExport<IMediator>();
        }

        public void Dispose()
        {
            Mef.ClassFactory.Dispose(classFactory);
        }
    }
}
