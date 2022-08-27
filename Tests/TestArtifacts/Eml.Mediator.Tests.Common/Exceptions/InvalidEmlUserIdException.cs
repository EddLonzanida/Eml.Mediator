using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class InvalidEmlUserIdException : AuthenticationException
{
    public InvalidEmlUserIdException()
        : base("Eml PiiUserId is not valid.")
    {
    }
}
