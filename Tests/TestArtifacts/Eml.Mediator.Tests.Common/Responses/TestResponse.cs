using System;using Eml.Mediator.Contracts;namespace Eml.Mediator.Tests.Common.Responses
{
    /// <summary>
    /// TestRequestAsyncEngine return value.
    /// </summary>
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; }        //<-Return Value

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
}