using System;

namespace Eml.Mediator.Exceptions;

public class MissingEngineException : Exception
{
    public MissingEngineException(string message)
        : base(message)
    {
    }
}
