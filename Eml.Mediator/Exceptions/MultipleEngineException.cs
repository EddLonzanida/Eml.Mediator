using System;

namespace Eml.Mediator.Exceptions
{
    public class MultipleEngineException : Exception
    {
        public MultipleEngineException(string message) 
            : base(message)
        {
        }
    }
}
