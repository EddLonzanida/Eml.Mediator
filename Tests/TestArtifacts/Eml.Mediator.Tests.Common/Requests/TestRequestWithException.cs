using System;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
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