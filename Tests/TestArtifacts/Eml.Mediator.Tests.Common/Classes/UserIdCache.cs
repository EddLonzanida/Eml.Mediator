using System;
using System.Collections.Generic;

namespace Eml.Mediator.Tests.Common.Classes
{
    public interface IIdTimestamp<out T>
    {
        T PiiUserId { get; }
        DateTime Timestamp { get; }
    }

    public static class UserIdCache<T>
    {
        public static Dictionary<string, IdTimestamp<T>> Items => new Dictionary<string, IdTimestamp<T>>();
    }

    public class IdTimestamp<T> : IIdTimestamp<T>
    {
        public T PiiUserId { get; }
        public T EmlUserId { get; }

        public DateTime Timestamp { get; }

        public IdTimestamp(T piiUserId, T emlUserId)
        {
            PiiUserId = piiUserId;
            EmlUserId = emlUserId;
            Timestamp = DateTime.Now;
        }
    }
}
