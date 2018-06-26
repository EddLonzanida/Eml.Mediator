using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequest2Engine : IRequestEngine<TestWithMultipleEngineRequest, TestResponse>
    {
        public TestResponse Get(TestWithMultipleEngineRequest request)
        {
            return new TestResponse(request.Id);
        }

        public void Dispose()
        {
        }
    }
}