using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestWithExceptionAsyncEngine : IRequestAsyncEngine<TestAsyncRequestWithException, TestResponse>
    {
        public Task<TestResponse> GetAsync(TestAsyncRequestWithException request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
