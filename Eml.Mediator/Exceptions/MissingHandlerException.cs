using System;

namespace Eml.Mediator.Exceptions;

public class MissingHandlerException(string message) : Exception(message);
