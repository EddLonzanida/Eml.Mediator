using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    public class TestRequest1AsyncEngine : IRequestAsyncEngine<TestAsyncRequestWithMultipleEngine, TestResponse>
    {
        public async Task<TestResponse> ExecuteAsync(TestAsyncRequestWithMultipleEngine request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
}
