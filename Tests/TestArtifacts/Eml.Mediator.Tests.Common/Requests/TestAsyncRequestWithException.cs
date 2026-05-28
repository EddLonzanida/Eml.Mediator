using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestHandlers;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestAsyncRequestWithException : IRequestAsync<TestAsyncRequestWithException, TestResponse>
{
    public string? CallSite { get; set; }

    public Guid Id { get; }

    /// <summary>
    ///     This request will be processed by <see cref="TestRequestWithExceptionAsyncHandler" />.
    /// </summary>
    public TestAsyncRequestWithException(Guid id)
    {
        Id = id;
    }
}
