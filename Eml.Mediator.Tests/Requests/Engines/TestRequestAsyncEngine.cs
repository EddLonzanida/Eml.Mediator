using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestRequestAsync, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestRequestAsync request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
}
