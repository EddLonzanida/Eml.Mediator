using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestHandlers;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestRequestWithException : IRequest<TestRequestWithException, TestResponse>
{
    public string? CallSite { get; set; }

    public Guid Id { get; }

    /// <summary>
    ///     This request will be processed by <see cref="TestRequestWithExceptionHandler" />.
    /// </summary>
    public TestRequestWithException(Guid id)
    {
        Id = id;
    }
}
