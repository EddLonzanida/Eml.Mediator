using System;

namespace Eml.Mediator.Exceptions;

public class MissingRequestException : Exception
{
    public MissingRequestException(string message)
        : base(message)
    {
    }
}
