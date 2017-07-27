using System;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestWithNoAsyncEngine : IRequestAsync<TestRequestWithNoAsyncEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithNoAsyncEngine(Guid id)
        {
            Id = id;
        }
    }
}