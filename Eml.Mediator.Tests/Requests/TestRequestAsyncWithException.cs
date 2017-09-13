using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestAsyncWithException : IRequestAsync<TestRequestAsyncWithException, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestAsyncWithException(Guid id)
        {
            Id = id;
        }
    }
}