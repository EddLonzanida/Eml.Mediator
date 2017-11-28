using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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