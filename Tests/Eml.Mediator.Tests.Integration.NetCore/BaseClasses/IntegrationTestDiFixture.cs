using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;

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
        services.AddSingleton(TimeProvider.System);
        services.Scan(scan => scan
            .FromAssemblyDependencies(typeof(IntegrationTestDiFixture).Assembly)
            // .FromAssemblyOf<IntegrationTestDiFixture>()

            // Register IMediator
            .AddClasses(classes => classes.AssignableTo<IMediator>())
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()

            // Register RequestHandlers, CommandHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestAsyncHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            // Register RequestHandlers, CommandHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()

            // Register CommandHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandAsyncHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            // Register CommandHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()

            // IDiDiscoverableTransient
            .AddClasses(classes => classes.AssignableTo(typeof(IDiDiscoverableTransient)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}
