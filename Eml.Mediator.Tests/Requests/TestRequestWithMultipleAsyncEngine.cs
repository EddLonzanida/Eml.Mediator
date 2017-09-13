using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestWithMultipleAsyncEngine : IRequestAsync<TestRequestWithMultipleAsyncEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithMultipleAsyncEngine(Guid id)
        {
            Id = id;
        }
    }
}