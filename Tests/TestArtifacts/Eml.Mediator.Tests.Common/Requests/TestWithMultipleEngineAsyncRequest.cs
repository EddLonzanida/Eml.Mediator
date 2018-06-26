using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithMultipleEngineAsyncRequest : IRequestAsync<TestWithMultipleEngineAsyncRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithMultipleEngineAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}