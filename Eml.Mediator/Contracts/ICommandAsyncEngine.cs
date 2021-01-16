using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    /// <summary>
    /// No implementations. Serves as a common denominator for all ICommandAsyncEngine&lt; T&gt;
    /// Transient.
    /// </summary>
    public interface ICommandAsyncEngine
    {
    }

    /// <summary>
    /// Transient.
    /// </summary>
    public interface ICommandAsyncEngine<in T> : ICommandAsyncEngine
        where T : ICommandAsync
    {
        Task ExecuteAsync(T command);
    }
}