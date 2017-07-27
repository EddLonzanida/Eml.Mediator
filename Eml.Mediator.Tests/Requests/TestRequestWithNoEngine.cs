using System;
using Eml.Mediator.Contracts;

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