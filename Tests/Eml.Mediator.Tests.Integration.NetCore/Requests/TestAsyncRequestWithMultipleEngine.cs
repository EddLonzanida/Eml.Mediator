using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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