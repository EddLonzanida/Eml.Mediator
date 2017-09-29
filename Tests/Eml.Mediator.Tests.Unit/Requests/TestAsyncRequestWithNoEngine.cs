using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
{
    public class TestAsyncRequestWithNoEngine : IRequestAsync<TestAsyncRequestWithNoEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestAsyncRequestWithNoEngine(Guid id)
        {
            Id = id;
        }
    }
}