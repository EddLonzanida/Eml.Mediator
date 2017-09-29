using System;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Responses
{
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; }

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
}