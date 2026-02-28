using System.Threading.Tasks;

namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all IRequestAsyncEngine&lt;in T1, T2&gt;
///     Transient.
/// </summary>
public interface IRequestAsyncEngine
{
}

/// <summary>
///     Transient.
/// </summary>
public interface IRequestAsyncEngine<in TRequest, TResponse> : IRequestAsyncEngine
    where TRequest : IRequestAsync<TRequest, TResponse>
    where TResponse : IResponse
{
    Task<TResponse> ExecuteAsync(TRequest request);
}
