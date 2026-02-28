using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Responses;

public class UserIdCacheResponse<T>(T piiUserId, T emlUserId) : IResponse
{
    public T PiiUserId { get; } = piiUserId;

    public T EmlUserId { get; } = emlUserId;
}
