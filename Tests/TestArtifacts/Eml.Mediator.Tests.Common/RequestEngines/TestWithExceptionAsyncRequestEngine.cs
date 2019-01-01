using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestWithExceptionAsyncEngine : IRequestAsyncEngine<TestWithExceptionAsyncRequest, TestResponse>
    {
        public Task<TestResponse> GetAsync(TestWithExceptionAsyncRequest request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
