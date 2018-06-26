using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithExceptionAsyncRequest : IRequestAsync<TestWithExceptionAsyncRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithExceptionAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}