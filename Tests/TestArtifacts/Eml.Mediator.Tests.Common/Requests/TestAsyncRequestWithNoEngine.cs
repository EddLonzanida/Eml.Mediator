using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestAsyncRequestWithNoEngine : IRequestAsync<TestAsyncRequestWithNoEngine, TestResponse>
{
    public Guid Id { get; }

    public TestAsyncRequestWithNoEngine(Guid id)
    {
        Id = id;
    }
}
