namespace Eml.Mediator.Contracts
{
    public interface IRequestAsync<T1, T2>
        where T1 : IRequestAsync<T1, T2>
        where T2 : IResponse
    {
    }
}