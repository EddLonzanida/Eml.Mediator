using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestEngines;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.Requests;

public class TestAsyncRequestWithException : IRequestAsync<TestAsyncRequestWithException, TestResponse>
{
    public Guid Id { get; }

    /// <summary>
    ///     This request will be processed by <see cref="TestRequestWithExceptionAsyncEngine" />.
    /// </summary>
    public TestAsyncRequestWithException(Guid id)
    {
        Id = id;
    }
}
