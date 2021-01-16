using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Classes
{
    public static class UserIdCacheAsyncRequestExtensions
    {
        public static UserIdCacheResponse<T> GetUserIdMemCache<T>(this UserIdCacheAsyncRequest<T> request, int maxCacheCount)
        {
            var nameIdentifier = request.NameIdentifier;

            if (UserIdCache<T>.Items.Count > maxCacheCount)
            {
                var threshHold = DateTime.Now.AddHours(-1);

                foreach (var item in UserIdCache<T>.Items)
                {
                    // purge all Ids that's idle for than 1 hour
                    if (item.Value.Timestamp <= threshHold)
                    {
                        UserIdCache<T>.Items.Remove(item.Key);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(nameIdentifier))
            {
                throw new AuthenticationException("Name Identifier is empty.");
            }

            if (UserIdCache<T>.Items.ContainsKey(nameIdentifier))
            {
                var cachedId = UserIdCache<T>.Items[nameIdentifier];

                if (cachedId != null)
                {
                    return new UserIdCacheResponse<T>(cachedId.PiiUserId, cachedId.EmlUserId);
                }
            }

            return null;
        }
    }
}
