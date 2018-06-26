using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithMultipleEngineRequest : IRequest<TestWithMultipleEngineRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithMultipleEngineRequest(Guid id)
        {
            Id = id;
        }
    }
}