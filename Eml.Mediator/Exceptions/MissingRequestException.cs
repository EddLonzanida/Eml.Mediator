using System;

namespace Eml.Mediator.Exceptions;

public class MissingRequestException(string message) : Exception(message);
