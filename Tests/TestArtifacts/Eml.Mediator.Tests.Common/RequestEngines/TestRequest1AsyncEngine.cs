using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequest1AsyncEngine : IRequestAsyncEngine<TestWithMultipleEngineAsyncRequest, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestWithMultipleEngineAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }

        public void Dispose()
        {
        }
    }
}
