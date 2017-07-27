using System;
using Eml.Mediator.Contracts;

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