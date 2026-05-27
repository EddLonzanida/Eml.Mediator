using Eml.Mediator.Contracts;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Eml.Mediator;

/// <summary>
///     Singleton.
/// </summary>
[method: DebuggerStepThrough]
public class Mediator(IServiceProvider classFactory) : IMediator
{
    [DebuggerStepThrough]
    public void Execute<TCommand>(TCommand command,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TCommand : ICommand
    {
        var items = classFactory.GetServices<ICommandHandler<TCommand>>();
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
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandHandler<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandHandler<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        command.CallSite = syncEngine.ToCallSite(callSiteFromHigherStack: command.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        syncEngine.Execute(command);
    }

    [DebuggerStepThrough]
    public async Task ExecuteAsync<TCommand>(TCommand commandAsync,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TCommand : ICommandAsync
    {
        var items = classFactory.GetServices<ICommandAsyncHandler<TCommand>>();
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
                                             $"{Environment.NewLine}Mediator should find Command Engine of type: {typeof(ICommandAsyncHandler<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(ICommandAsyncHandler<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandAsyncEngine." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        commandAsync.CallSite = asyncEngine.ToCallSite(callSiteFromHigherStack: commandAsync.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        await asyncEngine.ExecuteAsync(commandAsync);
    }

    [DebuggerStepThrough]
    public TResponse Execute<TRequest, TResponse>(IRequest<TRequest, TResponse> request,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestHandler<TRequest, TResponse>>();
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
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestHandler<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestHandler<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check if the class is implementing the interface: IRequestEngine." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        request.CallSite = syncEngine.ToCallSite(callSiteFromHigherStack: request.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        return syncEngine.Execute((TRequest)request);
    }

    //[DebuggerStepThrough]
    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(IRequestAsync<TRequest, TResponse> request,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TRequest : IRequestAsync<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestAsyncHandler<TRequest, TResponse>>();
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
                $"{Environment.NewLine}Mediator should find Request Engine of type: {typeof(IRequestAsyncHandler<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Engine type {typeof(IRequestAsyncHandler<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered." +
                $"{Environment.NewLine}Check if the class is implementing IRequestAsyncEngine." +
                $"{Environment.NewLine}Check if any of the constructor parameters for {typeof(TRequest).Name} are also in the container.");
        }

        request.CallSite = asyncEngine.ToCallSite(callSiteFromHigherStack: request.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

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
