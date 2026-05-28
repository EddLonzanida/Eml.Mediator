using System;

namespace Eml.Mediator.Exceptions
{
    public class MultipleHandlerException(string message) : Exception(message);
}
