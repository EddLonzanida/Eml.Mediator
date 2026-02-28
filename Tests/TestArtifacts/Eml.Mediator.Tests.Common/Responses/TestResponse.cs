using Eml.Mediator.Contracts;
using System;

namespace Eml.Mediator.Tests.Common.Responses;

/// <summary>
///     TestRequestAsyncEngine return value.
/// </summary>
public class TestResponse(Guid responseToRequestId) : IResponse
{
    public Guid ResponseToRequestId { get; } = responseToRequestId; //<-Return Value
}
