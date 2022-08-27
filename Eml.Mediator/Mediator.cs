using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eml.Mediator;

/// <summary>
///     Singleton.
/// </summary>
public class Mediator : IMediator
{
    private readonly IServiceProvider classFactory;

    public Mediator(IServiceProvider classFactory)
    {
        this.classFactory = classFactory;
    }

    public void Execute<T>(T command)
        where T : ICommand
    {
        var items = classFactory.GetServices<ICommandEngine<T>>();
        var engines = items.ToList();

        // IServiceProvider picks up items that was registered last
        var syncEngine = engines.LastOrDefault();

        if (syncEngine == null)
        {
            throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(T)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandEngine<T>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandEngine<T>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        syncEngine.Execute(command);
    }

    public async Task ExecuteAsync<T>(T commandAsync)
        where T : ICommandAsync
    {
        var items = classFactory.GetServices<ICommandAsyncEngine<T>>();
        var engines = items.ToList();

        // IServiceProvider picks up items that was registered last
        var asyncEngine = engines.LastOrDefault();

        if (asyncEngine == null)
        {
            throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(T)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandAsyncEngine<T>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandAsyncEngine<T>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandAsyncEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        await asyncEngine.ExecuteAsync(commandAsync);
    }

    public T2 Execute<T1, T2>(IRequest<T1, T2> request)
        where T1 : IRequest<T1, T2>
        where T2 : IResponse
    {
        var items = classFactory.GetServices<IRequestEngine<T1, T2>>();
        var engines = items.ToList();

        // IServiceProvider picks up items that was registered last
        var syncEngine = engines.LastOrDefault();

        if (syncEngine == null)
        {
            throw new MissingEngineException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(T1)}. " +
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestEngine<T1, T2>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestEngine<T1, T2>)} are all discoverable." +
                $"{Environment.NewLine}Check if the class is implementing the interface: IRequestEngine." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        return syncEngine.Execute((T1) request);
    }

    public async Task<T2> ExecuteAsync<T1, T2>(IRequestAsync<T1, T2> request)
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
        var items = classFactory.GetServices<IRequestAsyncEngine<T1, T2>>();
        var engines = items.ToList();

        // IServiceProvider picks up items that was registered last
        var asyncEngine = engines.LastOrDefault();

        if (asyncEngine == null)
        {
            throw new MissingEngineException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(T1)}." +
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestAsyncEngine<T1, T2>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestAsyncEngine<T1, T2>)} are all discoverable." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered." +
                $"{Environment.NewLine}Check if the class is implementing IRequestAsyncEngine." +
                $"{Environment.NewLine}Check if any of the constructor parameters for {typeof(T1).Name} are also in the container.");
        }

        return await asyncEngine.ExecuteAsync((T1) request);
    }
}
