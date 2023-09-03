using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestRequestWithMultipleEngine : IRequest<TestRequestWithMultipleEngine, TestResponse>
{
    public Guid Id { get; }

    public TestRequestWithMultipleEngine(Guid id)
    {
        Id = id;
    }
}
