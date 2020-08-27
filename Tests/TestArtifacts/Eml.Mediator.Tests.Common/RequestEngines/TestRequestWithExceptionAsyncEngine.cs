#if NETFULL
using System.ComponentModel.Composition;
#endif
using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestRequestWithExceptionAsyncEngine : IRequestAsyncEngine<TestAsyncRequestWithException, TestResponse>
    {
        public Task<TestResponse> ExecuteAsync(TestAsyncRequestWithException request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
