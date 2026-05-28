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
        var handlers = items.ToList();

        if (handlers.Count > 1)
        {
            var errorMessages = GetMultipleHandlerExceptionMessage(handlers);

            throw new MultipleHandlerException($"Check the following Command handlers:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var syncHandler = handlers.LastOrDefault();

        if (syncHandler is null)
        {
            throw new MissingHandlerException($"{Environment.NewLine}Could not find a Command of type {typeof(TCommand)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Handler of type: {typeof(ICommandHandler<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Handler type {typeof(ICommandHandler<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandHandler." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        command.CallSite = syncHandler.ToCallSite(callSiteFromHigherStack: command.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        syncHandler.Execute(command);
    }

    [DebuggerStepThrough]
    public async Task ExecuteAsync<TCommand>(TCommand commandAsync,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TCommand : ICommandAsync
    {
        var items = classFactory.GetServices<ICommandAsyncHandler<TCommand>>();
        var handlers = items.ToList();

        if (handlers.Count > 1)
        {
            var errorMessages = GetMultipleHandlerExceptionMessage(handlers);

            throw new MultipleHandlerException($"Check the following Command handlers:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var asyncHandler = handlers.LastOrDefault();

        if (asyncHandler is null)
        {
            throw new MissingHandlerException($"{Environment.NewLine}Could not find a Command of type {typeof(TCommand)}. " +
                                             $"{Environment.NewLine}Mediator should find Command Handler of type: {typeof(ICommandAsyncHandler<TCommand>)}" +
                                             $"{Environment.NewLine}Make sure the constructor parameter(s) of Handler type {typeof(ICommandAsyncHandler<TCommand>)} are all discoverable." +
                                             $"{Environment.NewLine}Check if the class is implementing the interface: ICommandAsyncHandler." +
                                             $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        commandAsync.CallSite = asyncHandler.ToCallSite(callSiteFromHigherStack: commandAsync.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        await asyncHandler.ExecuteAsync(commandAsync);
    }

    [DebuggerStepThrough]
    public TResponse Execute<TRequest, TResponse>(IRequest<TRequest, TResponse> request,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestHandler<TRequest, TResponse>>();
        var handlers = items.ToList();

        if (handlers.Count > 1)
        {
            var errorMessages = GetMultipleHandlerExceptionMessage(handlers);

            throw new MultipleHandlerException($"Check the following Request handlers:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var syncHandler = handlers.LastOrDefault();

        if (syncHandler is null)
        {
            throw new MissingHandlerException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(TRequest)}. " +
                $"{Environment.NewLine}Mediator should find Request Handler of type: {typeof(IRequestHandler<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Handler type {typeof(IRequestHandler<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check if the class is implementing the interface: IRequestHandler." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered.");
        }

        request.CallSite = syncHandler.ToCallSite(callSiteFromHigherStack: request.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        return syncHandler.Execute((TRequest)request);
    }

    //[DebuggerStepThrough]
    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(IRequestAsync<TRequest, TResponse> request,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where TRequest : IRequestAsync<TRequest, TResponse>
        where TResponse : IResponse
    {
        var items = classFactory.GetServices<IRequestAsyncHandler<TRequest, TResponse>>();
        var handlers = items.ToList();

        if (handlers.Count > 1)
        {
            var errorMessages = GetMultipleHandlerExceptionMessage(handlers);

            throw new MultipleHandlerException($"Check the following Request handlers:{errorMessages}");
        }

        // IServiceProvider picks up items that was registered last
        var asyncHandler = handlers.LastOrDefault();

        if (asyncHandler is null)
        {
            throw new MissingHandlerException(
                $"{Environment.NewLine}Could not find a Request of type {typeof(TRequest)}." +
                $"{Environment.NewLine}Mediator should find Request Handler of type: {typeof(IRequestAsyncHandler<TRequest, TResponse>)}" +
                $"{Environment.NewLine}Make sure the constructor parameter(s) of Handler type {typeof(IRequestAsyncHandler<TRequest, TResponse>)} are all discoverable." +
                $"{Environment.NewLine}Check IServiceCollection if IMediator is registered." +
                $"{Environment.NewLine}Check if the class is implementing IRequestAsyncHandler." +
                $"{Environment.NewLine}Check if any of the constructor parameters for {typeof(TRequest).Name} are also in the container.");
        }

        request.CallSite = asyncHandler.ToCallSite(callSiteFromHigherStack: request.CallSite,
            callerFilePath: callerFilePath,
            callerLineNumber: callerLineNumber);

        return await asyncHandler.ExecuteAsync((TRequest)request);
    }

    [DebuggerStepThrough]
    private static string GetMultipleHandlerExceptionMessage<THandler>(IEnumerable<THandler> handlers)
    {
        var errorMessages = handlers.ToList()
            .ConvertAll(r => r?.GetType().FullName ?? string.Empty)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList()
            .ConvertAll(r => $"->{r}");

        return $"{Environment.NewLine}{string.Join(Environment.NewLine, errorMessages)}{Environment.NewLine}";
    }
}
