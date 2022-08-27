using System;

namespace Eml.Mediator.Exceptions;

public class MissingCommandException : Exception
{
    public MissingCommandException(string message)
        : base(message)
    {
    }
}
