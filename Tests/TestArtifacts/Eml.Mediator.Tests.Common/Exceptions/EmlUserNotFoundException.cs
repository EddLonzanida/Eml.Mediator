using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class EmlUserNotFoundException : AuthenticationException
{
    public EmlUserNotFoundException(string piiUserId)
        : base($"Eml PiiUserId not found: {piiUserId}. Please log out and log in again.")
    {
    }
}
