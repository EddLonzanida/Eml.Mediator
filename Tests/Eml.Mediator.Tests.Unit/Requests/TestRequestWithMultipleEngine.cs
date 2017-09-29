using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
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