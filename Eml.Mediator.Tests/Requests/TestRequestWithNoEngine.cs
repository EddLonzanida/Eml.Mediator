using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
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