using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eml.Mediator;

/// <summary>
///     Singleton.
/// </summary>
[method: DebuggerStepThrough]
public class Mediator(IServiceProvider classFactory) : IMediator
{
    [DebuggerStepThrough]
    public void Execute<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        var items = classFactory.GetServices<ICommandEngine<TCommand>>();
        var engines = items.ToList();

        if (engines.Count > 1)
        {
            var errorMessages = GetMultipleEngineExceptionMessage(engines);

            throw new MultipleEngineException($"Check the following Command engines:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var syncEngine = engines.LastOrDefault();

        if (syncEngine is null)
        {
            throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(TCommand)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandEngine<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandEngine<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        syncEngine.Execute(command);
    }

    [DebuggerStepThrough]
    public async Task ExecuteAsync<TCommand>(TCommand commandAsync)
        where TCommand : ICommandAsync
    {
        var items = classFactory.GetServices<ICommandAsyncEngine<TCommand>>();
        var engines = items.ToList();

        if (engines.Count > 1)
        {
            var errorMessages = GetMultipleEngineExceptionMessage(engines);

            throw new MultipleEngineException($"Check the following Command engines:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var asyncEngine = engines.LastOrDefault();

        if (asyncEngine is null)
        {
            throw new MissingEngineException($"{Environment.NewLine}Could not find a Command of type {typeof(TCommand)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandAsyncEngine<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandAsyncEngine<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandAsyncEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        await asyncEngine.ExecuteAsync(commandAsync);
    }

    [DebuggerStepThrough]
    public TResponse Execute<TRequest, TResponse>(IRequest<TRequest, TResponse> request)
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestEngine<TRequest, TResponse>>();
        var engines = items.ToList();

        if (engines.Count > 1)
        {
            var errorMessages = GetMultipleEngineExceptionMessage(engines);

            throw new MultipleEngineException($"Check the following Request engines:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var syncEngine = engines.LastOrDefault();

        if (syncEngine is null)
        {
            throw new MissingEngineException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(TRequest)}. " +
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestEngine<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestEngine<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check if the class is implementing the interface: IRequestEngine." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        return syncEngine.Execute((TRequest)request);
    }

    [DebuggerStepThrough]
    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(IRequestAsync<TRequest, TResponse> request)
        where TRequest : IRequestAsync<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestAsyncEngine<TRequest, TResponse>>();
        var engines = items.ToList();

        if (engines.Count > 1)
        {
            var errorMessages = GetMultipleEngineExceptionMessage(engines);

            throw new MultipleEngineException($"Check the following Request engines:{errorMessages}");
        }


        // IServiceProvider picks up items that was registered last
        var asyncEngine = engines.LastOrDefault();

        if (asyncEngine is null)
        {
            throw new MissingEngineException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(TRequest)}." +
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestAsyncEngine<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestAsyncEngine<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered." +
                $"{Environment.NewLine}Check if the class is implementing IRequestAsyncEngine." +
                $"{Environment.NewLine}Check if any of the constructor parameters for {typeof(TRequest).Name} are also in the container.");
        }

        return await asyncEngine.ExecuteAsync((TRequest)request);
    }

    [DebuggerStepThrough]
    private static string GetMultipleEngineExceptionMessage<TEngine>(IEnumerable<TEngine> engines)
    {
        var errorMessages = engines.ToList()
            .ConvertAll(r => r?.GetType().FullName ?? string.Empty)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList()
            .ConvertAll(r => $"->{r}");

        return $"{Environment.NewLine}{string.Join(Environment.NewLine, errorMessages)}{Environment.NewLine}";
    }
}
