using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    public class TestRequest2Engine : IRequestEngine<TestRequestWithMultipleEngine, TestResponse>
    {
        public TestResponse Execute(TestRequestWithMultipleEngine request)
        {
            return new TestResponse(request.Id);
        }
    }
}