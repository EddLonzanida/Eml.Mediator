using System.Threading.Tasks;

namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all ICommandAsyncHandler&lt; T&gt;
///     Transient.
/// </summary>
public interface ICommandAsyncHandler : IHandler
{
}

/// <summary>
///     Transient.
/// </summary>
public interface ICommandAsyncHandler<in TCommand> : ICommandAsyncHandler
    where TCommand : ICommandAsync
{
    Task ExecuteAsync(TCommand command);
}
