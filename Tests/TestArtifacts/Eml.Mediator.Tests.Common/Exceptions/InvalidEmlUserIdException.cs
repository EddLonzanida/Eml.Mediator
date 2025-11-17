using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class InvalidEmlUserIdException() : AuthenticationException("Eml PiiUserId is not valid.");
