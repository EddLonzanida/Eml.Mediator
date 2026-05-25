namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all ICommandEngine&lt; T&gt;
///     Transient.
/// </summary>
public interface ICommandEngine : IEngine
{
}

/// <summary>
///     Transient.
/// </summary>
public interface ICommandEngine<in TCommand> : ICommandEngine
    where TCommand : ICommand
{
    void Execute(TCommand command);
}
