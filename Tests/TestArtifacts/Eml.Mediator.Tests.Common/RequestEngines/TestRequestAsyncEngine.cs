using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    /// <summary>
    /// DI signature: IRequestAsyncEngine&lt;TestAsyncRequest, TestResponse&gt;.
    /// <inheritdoc cref="IRequestAsyncEngine{TestAsyncRequest, TestResponse}"/>
    /// </summary>
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestAsyncRequest, TestResponse>
    {
        public async Task<TestResponse> ExecuteAsync(TestAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
}
