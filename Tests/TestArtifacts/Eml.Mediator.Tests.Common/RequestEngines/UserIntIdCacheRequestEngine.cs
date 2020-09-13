#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using System.Composition;
#endif
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Eml.Mediator.Tests.Common.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    public class UserIntIdCacheRequestEngine : IRequestAsyncEngine<UserIdCacheAsyncRequest<int>, UserIdCacheResponse<int>>
    {
        private const int MaxCacheCount = 500;

        private readonly IEmlRepository<int> emlUserPiiRepository;
        private readonly IPiiRepository<int> piiUserPiiRepository;

        [ImportingConstructor]
        public UserIntIdCacheRequestEngine(IPiiRepository<int> piiUserPiiRepository, IEmlRepository<int> emlUserPiiRepository)
        {
            this.piiUserPiiRepository = piiUserPiiRepository;
            this.emlUserPiiRepository = emlUserPiiRepository;
        }

        public async Task<UserIdCacheResponse<int>> ExecuteAsync(UserIdCacheAsyncRequest<int> request)
        {
            // Retrieve from memory
            var userIdCacheResponse = request.GetUserIdMemCache(MaxCacheCount);

            if (userIdCacheResponse != null)
            {
                return userIdCacheResponse;
            }

            // Retrieve from db
            var nameIdentifier = request.NameIdentifier;
            var email = nameIdentifier;
            var piiUser = await piiUserPiiRepository.FindAsync(email);

            if (piiUser == null)
            {
                throw new PiiUserNotFoundException(nameIdentifier);
            }

            var piiUserId = piiUser.Id;
            var emlUser = await emlUserPiiRepository.FindAsync(piiUserId);

            if (emlUser == null)
            {
                throw new EmlUserNotFoundException(piiUserId.ToString());
            }

            var emlUserId = emlUser.Id;
            var idTimestamp = new IdTimestamp<int>(piiUserId, emlUserId);

            // Save in memory for re-usability
            UserIdCache<int>.Items.Add(nameIdentifier, idTimestamp);

            return new UserIdCacheResponse<int>(piiUserId, emlUserId);
        }

        public void Dispose()
        {
        }
    }
}
