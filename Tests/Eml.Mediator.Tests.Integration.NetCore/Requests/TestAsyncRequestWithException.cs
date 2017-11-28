using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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