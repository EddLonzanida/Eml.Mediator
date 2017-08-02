using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequest2AsyncEngine : IRequestAsyncEngine<TestRequestWithMultipleAsyncEngine, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestRequestWithMultipleAsyncEngine request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
}
