using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
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