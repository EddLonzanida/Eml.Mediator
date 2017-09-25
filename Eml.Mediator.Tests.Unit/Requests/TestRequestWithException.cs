using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
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