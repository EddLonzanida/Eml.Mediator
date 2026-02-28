using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestAsyncRequestWithNoEngine(Guid id) : IRequestAsync<TestAsyncRequestWithNoEngine, TestResponse>
{
    public Guid Id { get; } = id;
}
