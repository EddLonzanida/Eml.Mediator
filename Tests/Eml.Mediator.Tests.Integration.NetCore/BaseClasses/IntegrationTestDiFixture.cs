using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.BaseClasses;

public class IntegrationTestDiFixture : IDisposable
{
    public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    public IntegrationTestDiFixture()
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyDependencies(typeof(IntegrationTestDiFixture).Assembly)
            // .FromAssemblyOf<IntegrationTestDiFixture>()

            // Register IMediator
            .AddClasses(classes => classes.AssignableTo<IMediator>())
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()

            // Register RequestEngines, CommandEngines
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestAsyncEngine<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            // Register RequestEngines, CommandEngines
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestEngine<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()

            // Register CommandEngines
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandAsyncEngine<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            // Register CommandEngines
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandEngine<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()

            // IDiDiscoverableTransient
            .AddClasses(classes => classes.AssignableTo(typeof(IDiDiscoverableTransient)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}

[CollectionDefinition(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDiFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
