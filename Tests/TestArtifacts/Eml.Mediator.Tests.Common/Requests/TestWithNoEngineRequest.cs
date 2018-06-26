using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithNoEngineRequest : IRequest<TestWithNoEngineRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithNoEngineRequest(Guid id)
        {
            Id = id;
        }
    }
}