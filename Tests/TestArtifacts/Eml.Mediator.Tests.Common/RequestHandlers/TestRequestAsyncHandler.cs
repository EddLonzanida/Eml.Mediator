using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.RequestHandlers;

/// <summary>
///     DI signature: IRequestAsyncHandler&lt;TestAsyncRequest, TestResponse&gt;.
///     <inheritdoc cref="IRequestAsyncHandler{TestAsyncRequest,TestResponse}" />
/// </summary>
public class TestRequestAsyncHandler : IRequestAsyncHandler<TestAsyncRequest, TestResponse>
{
    public async Task<TestResponse> ExecuteAsync(TestAsyncRequest request)
    {
        return await Task.Run(() => new TestResponse(request.Id));
    }
}
