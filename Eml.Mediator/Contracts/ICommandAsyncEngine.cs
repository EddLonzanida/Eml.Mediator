using System.Threading.Tasks;

namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all ICommandAsyncEngine&lt; T&gt;
///     Transient.
/// </summary>
public interface ICommandAsyncEngine : IEngine
{
}

/// <summary>
///     Transient.
/// </summary>
public interface ICommandAsyncEngine<in TCommand> : ICommandAsyncEngine
    where TCommand : ICommandAsync
{
    Task ExecuteAsync(TCommand command);
}
