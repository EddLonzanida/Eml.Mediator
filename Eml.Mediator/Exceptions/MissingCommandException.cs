using System;

namespace Eml.Mediator.Exceptions;

public class MissingCommandException(string message) : Exception(message);
