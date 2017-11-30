#if NETFULL
using System.ComponentModel.Composition;
#endif
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestAsyncRequest, TestResponse>
    {
        /// <inheritdoc/>
        /// <summary>
        /// Implementation can be found in <see cref="TestRequestAsyncEngine"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TestResponse> GetAsync(TestAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }

        public void Dispose()
        {
        }
    }
}
