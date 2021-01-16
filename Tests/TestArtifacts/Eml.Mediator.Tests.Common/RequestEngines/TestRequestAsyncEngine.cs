using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestAsyncRequest, TestResponse>
    {
        /// <inheritdoc/>
        /// <summary>
        /// Implementation can be found in <see cref="TestRequestAsyncEngine"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TestResponse> ExecuteAsync(TestAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }

        public void Dispose()
        {
        }
    }
}
