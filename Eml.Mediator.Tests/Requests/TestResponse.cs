using System;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests
{
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; private set; }

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
}