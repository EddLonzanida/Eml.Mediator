#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using System.Composition;
#endif
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestRequestWithExceptionEngine : IRequestEngine<TestRequestWithException, TestResponse>
    {
        public TestResponse Execute(TestRequestWithException request)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}