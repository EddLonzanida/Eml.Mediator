using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestEngines;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestRequest : IRequest<TestRequest, TestResponse>
{
    public Guid Id { get; }

    /// <summary>
    ///     This request will be processed by <see cref="TestRequestEngine" />.
    /// </summary>
    public TestRequest(Guid id)
    {
        Id = id;
    }
}
