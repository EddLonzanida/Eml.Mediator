using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Responses;

public class UserIdCacheResponse<T> : IResponse
{
    public T PiiUserId { get; }

    public T EmlUserId { get; }

    public UserIdCacheResponse(T piiUserId, T emlUserId)
    {
        PiiUserId = piiUserId;
        EmlUserId = emlUserId;
    }
}
