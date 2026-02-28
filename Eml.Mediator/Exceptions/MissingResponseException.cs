using System;

namespace Eml.Mediator.Exceptions;

public class MissingResponseException(string message) : Exception(message);
