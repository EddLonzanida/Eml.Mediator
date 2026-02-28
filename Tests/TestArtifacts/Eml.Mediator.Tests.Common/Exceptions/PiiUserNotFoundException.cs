using System.Security.Authentication;

namespace Eml.Mediator.Tests.Common.Exceptions;

public class PiiUserNotFoundException(string nameIdentifier) : AuthenticationException($"Pii user not found: {nameIdentifier}. Please log out and log in again.");
