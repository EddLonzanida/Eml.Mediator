using System;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestAsyncRequest : IRequestAsync<TestAsyncRequest, TestResponse>
    {
        public Guid Id { get; private set; }

        public TestAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}