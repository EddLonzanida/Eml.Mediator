using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestRequestWithMultipleHandler(Guid id) : IRequest<TestRequestWithMultipleHandler, TestResponse>
{
    public string? CallSite { get; set; }

    public Guid Id { get; } = id;
}
