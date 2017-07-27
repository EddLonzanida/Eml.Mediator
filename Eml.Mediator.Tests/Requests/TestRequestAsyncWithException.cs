using System;
using Eml.Mediator.Contracts;

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