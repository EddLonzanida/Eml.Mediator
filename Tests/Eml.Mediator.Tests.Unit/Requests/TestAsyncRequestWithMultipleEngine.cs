using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
{
    public class TestAsyncRequestWithMultipleEngine : IRequestAsync<TestAsyncRequestWithMultipleEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestAsyncRequestWithMultipleEngine(Guid id)
        {
            Id = id;
        }
    }
}