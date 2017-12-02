using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestEngine : IRequestEngine<TestRequest, TestResponse>
    {
        public TestResponse Get(TestRequest request)
        {
            return new TestResponse(request.Id);
        }

        public void Dispose()
        {
        }
    }
}