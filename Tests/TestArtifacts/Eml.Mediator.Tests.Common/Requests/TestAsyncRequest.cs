using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestHandlers;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestAsyncRequest : IRequestAsync<TestAsyncRequest, TestResponse>
{
    public string? CallSite { get; set; }

    public Guid Id { get; }

    /// <summary>
    ///     This request will be processed by <see cref="TestRequestAsyncHandler" />.
    /// </summary>
    public TestAsyncRequest(Guid id)
    {
        Id = id;
    }
}
