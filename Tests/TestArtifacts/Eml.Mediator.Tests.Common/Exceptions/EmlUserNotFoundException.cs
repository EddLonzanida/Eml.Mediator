using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class EmlUserNotFoundException(string piiUserId) : AuthenticationException($"Eml PiiUserId not found: {piiUserId}. Please log out and log in again.");
