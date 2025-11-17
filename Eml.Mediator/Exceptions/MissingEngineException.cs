using System;

namespace Eml.Mediator.Exceptions;

public class MissingEngineException(string message) : Exception(message);
