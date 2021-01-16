using System;

namespace Eml.Mediator.Exceptions
{
    public class MissingResponseException : Exception
    {
        public MissingResponseException(string message)
            : base(message)
        {
        }
    }
}