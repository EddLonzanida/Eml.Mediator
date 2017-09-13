using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestWithMultipleEngine : IRequest<TestRequestWithMultipleEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithMultipleEngine(Guid id)
        {
            Id = id;
        }
    }
}