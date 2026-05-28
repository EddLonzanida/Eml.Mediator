namespace Eml.Mediator.Contracts;

/// <summary>
///     No implementations. Serves as a common denominator for all IRequestAsync&lt;T1, T2&gt;
/// </summary>
public interface IRequestAsync : IRequestCallSite
{
}

public interface IRequestAsync<TRequest, TResponse> : IRequestAsync
    where TRequest : IRequestAsync<TRequest, TResponse>
    where TResponse : IResponse
{
}
