using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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