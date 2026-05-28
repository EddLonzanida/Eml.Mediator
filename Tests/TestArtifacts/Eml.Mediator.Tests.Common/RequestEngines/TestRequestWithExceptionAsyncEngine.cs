using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.RequestHandlers;

public class TestRequestWithExceptionAsyncHandler : IRequestAsyncHandler<TestAsyncRequestWithException, TestResponse>
{
    public Task<TestResponse> ExecuteAsync(TestAsyncRequestWithException request)
    {
        throw new NotImplementedException();
    }
}
