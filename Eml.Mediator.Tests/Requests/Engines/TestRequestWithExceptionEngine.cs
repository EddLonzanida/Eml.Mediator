using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestWithExceptionEngine : IRequestEngine<TestRequestWithException, TestResponse>
    {
        public TestResponse Get(TestRequestWithException request)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}