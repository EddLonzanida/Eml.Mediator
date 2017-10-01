#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
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
