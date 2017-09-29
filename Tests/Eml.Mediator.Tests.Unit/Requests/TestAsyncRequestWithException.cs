using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
{
    public class TestAsyncRequestWithException : IRequestAsync<TestAsyncRequestWithException, TestResponse>
    {
        public Guid Id { get; }

        public TestAsyncRequestWithException(Guid id)
        {
            Id = id;
        }
    }
}