using System;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestWithException : IRequest<TestRequestWithException, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithException(Guid id)
        {
            Id = id;
        }
    }
}