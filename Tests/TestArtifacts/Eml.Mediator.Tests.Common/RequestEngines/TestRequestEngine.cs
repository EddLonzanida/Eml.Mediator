using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    public class TestRequestEngine : IRequestEngine<TestRequest, TestResponse>
    {
        public TestResponse Execute(TestRequest request)
        {
            return new TestResponse(request.Id);
        }
    }
}