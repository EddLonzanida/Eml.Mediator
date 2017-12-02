using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
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