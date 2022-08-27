using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class PiiUserNotFoundException : AuthenticationException
{
    public PiiUserNotFoundException(string nameIdentifier)
        : base($"Pii user not found: {nameIdentifier}. Please log out and log in again.")
    {
    }
}
