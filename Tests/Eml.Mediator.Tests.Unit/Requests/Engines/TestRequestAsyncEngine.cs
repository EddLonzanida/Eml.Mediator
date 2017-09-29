#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestAsyncRequest, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }

        public void Dispose()
        {
        }
    }
}
