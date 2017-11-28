using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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