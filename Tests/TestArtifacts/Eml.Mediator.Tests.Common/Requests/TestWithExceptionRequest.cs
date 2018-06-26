using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestWithExceptionRequest : IRequest<TestWithExceptionRequest, TestResponse>
    {
        public Guid Id { get; }

        public TestWithExceptionRequest(Guid id)
        {
            Id = id;
        }
    }
}