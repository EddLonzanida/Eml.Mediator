using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Eml.Mediator.Tests.Common.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.RequestEngines;

public class UserIntIdCacheRequestEngine(IPiiRepository<int> piiUserPiiRepository, IEmlRepository<int> emlUserPiiRepository, TimeProvider timeProvider)
    : IRequestAsyncEngine<UserIdCacheAsyncRequest<int>, UserIdCacheResponse<int>>
{
    private const int MaxCacheCount = 500;

    public async Task<UserIdCacheResponse<int>> ExecuteAsync(UserIdCacheAsyncRequest<int> request)
    {
        // Retrieve from memory
        var userIdCacheResponse = request.GetUserIdMemCache(MaxCacheCount, timeProvider);

        if (userIdCacheResponse is not null)
        {
            return userIdCacheResponse;
        }

        // Retrieve from db
        var nameIdentifier = request.NameIdentifier;
        var email = nameIdentifier;

        var piiUser = await piiUserPiiRepository.FindAsync(email);

        if (piiUser is null)
        {
            throw new PiiUserNotFoundException(nameIdentifier);
        }

        var piiUserId = piiUser.Id;
        var emlUser = await emlUserPiiRepository.FindAsync(piiUserId);

        if (emlUser is null)
        {
            throw new EmlUserNotFoundException(piiUserId.ToString());
        }

        var emlUserId = emlUser.Id;
        var idTimestamp = new IdTimestamp<int>(piiUserId, emlUserId, timeProvider);

        // Save in memory for re-usability
        UserIdCache<int>.Items.Add(nameIdentifier, idTimestamp);

        return new UserIdCacheResponse<int>(piiUserId, emlUserId);
    }
}
