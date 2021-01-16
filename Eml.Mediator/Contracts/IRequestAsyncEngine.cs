using System.Threading.Tasks;

namespace Eml.Mediator.Contracts
{
    /// <summary>
    /// No implementations. Serves as a common denominator for all IRequestAsyncEngine&lt;in T1, T2&gt;
    /// Transient.
    /// </summary>
    public interface IRequestAsyncEngine
    {
    }

    /// <summary>
    /// Transient.
    /// </summary>
    public interface IRequestAsyncEngine<in T1, T2> : IRequestAsyncEngine
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
        Task<T2> ExecuteAsync(T1 request);
    }
}