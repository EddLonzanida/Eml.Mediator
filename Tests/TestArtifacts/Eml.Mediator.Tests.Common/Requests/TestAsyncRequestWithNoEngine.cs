using System;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
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