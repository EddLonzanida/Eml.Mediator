using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.RequestHandlers;

public class TestRequest2AsyncHandler : IRequestAsyncHandler<TestAsyncRequestWithMultipleHandler, TestResponse>
{
    public async Task<TestResponse> ExecuteAsync(TestAsyncRequestWithMultipleHandler request)
    {
        return await Task.Run(() => new TestResponse(request.Id));
    }
}
