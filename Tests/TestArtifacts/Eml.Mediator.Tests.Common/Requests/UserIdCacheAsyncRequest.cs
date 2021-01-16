using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class UserIdCacheAsyncRequest<T> : IRequestAsync<UserIdCacheAsyncRequest<T>, UserIdCacheResponse<T>>
    {
        public string NameIdentifier{ get; }

        /// <summary>
        /// This request will be processed by UserIntIdCacheRequestEngine.
        /// </summary>
        public UserIdCacheAsyncRequest(string nameIdentifier)
        {
            NameIdentifier = nameIdentifier;
        }
    }
}
