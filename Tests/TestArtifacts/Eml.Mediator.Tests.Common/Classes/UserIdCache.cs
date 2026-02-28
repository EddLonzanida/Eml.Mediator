using System;
using System.Collections.Generic;

namespace Eml.Mediator.Tests.Common.Classes;

public interface IIdTimestamp<out T>
{
    T PiiUserId { get; }

    DateTime Timestamp { get; }
}

public static class UserIdCache<T>
{
    public static Dictionary<string, IdTimestamp<T>> Items => new();
}

public class IdTimestamp<T>(T piiUserId, T emlUserId, TimeProvider timeProvider)
    : IIdTimestamp<T>
{
    public T EmlUserId { get; } = emlUserId;

    public T PiiUserId { get; } = piiUserId;

    public DateTime Timestamp { get; } = timeProvider.GetUtcNow().UtcDateTime;
}
