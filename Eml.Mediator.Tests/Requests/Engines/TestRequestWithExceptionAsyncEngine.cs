using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestWithExceptionAsyncEngine : IRequestAsyncEngine<TestRequestAsyncWithException, TestResponse>
    {
        public Task<TestResponse> GetAsync(TestRequestAsyncWithException request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
