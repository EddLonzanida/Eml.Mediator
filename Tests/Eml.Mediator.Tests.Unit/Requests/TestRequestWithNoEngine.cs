using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
{
    public class TestRequestWithNoEngine : IRequest<TestRequestWithNoEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithNoEngine(Guid id)
        {
            Id = id;
        }
    }
}