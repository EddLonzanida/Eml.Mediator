using System;
using Eml.Mediator.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDiBase
    {
        protected readonly IMediator mediator;
        protected readonly IServiceProvider classFactory;

        protected IntegrationTestDiBase()
        {
            classFactory = IntegrationTestDiFixture.ServiceProvider;
            mediator = classFactory.GetRequiredService<IMediator>();
        }
    }
}
