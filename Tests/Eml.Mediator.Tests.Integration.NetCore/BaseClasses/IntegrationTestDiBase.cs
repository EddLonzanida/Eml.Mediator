using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

[assembly: AssemblyFixture(typeof(IntegrationTestDiFixture))]
namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses;

public abstract class IntegrationTestDiBase
{
    protected readonly IServiceProvider classFactory;
    protected readonly IMediator mediator;

    protected IntegrationTestDiBase()
    {
        classFactory = IntegrationTestDiFixture.ServiceProvider;
        mediator = classFactory.GetRequiredService<IMediator>();
    }
}
