using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequestWithExceptionAsyncEngine : IRequestAsyncEngine<TestRequestAsyncWithException, TestResponse>
    {
        public Task<TestResponse> GetAsync(TestRequestAsyncWithException request)
        {
            throw new NotImplementedException();
        }
    }
}
