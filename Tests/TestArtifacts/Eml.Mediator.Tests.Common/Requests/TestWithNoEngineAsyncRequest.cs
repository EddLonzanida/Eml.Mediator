using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithNoEngineAsyncRequest : IRequestAsync<TestWithNoEngineAsyncRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithNoEngineAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}