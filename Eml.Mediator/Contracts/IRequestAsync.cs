namespace Eml.Mediator.Contracts
{
    /// <summary>
    /// Base Interface used to identify IRequestAsync&lt;T1, T2&gt;
    /// </summary>
    public interface IRequestAsync
    {
    }

    public interface IRequestAsync<T1, T2> : IRequestAsync
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
    }
}