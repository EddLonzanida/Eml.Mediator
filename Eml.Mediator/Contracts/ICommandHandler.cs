namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all ICommandHandler&lt; T&gt;
///     Transient.
/// </summary>
public interface ICommandHandler : IHandler
{
}

/// <summary>
///     Transient.
/// </summary>
public interface ICommandHandler<in TCommand> : ICommandHandler
    where TCommand : ICommand
{
    void Execute(TCommand command);
}
