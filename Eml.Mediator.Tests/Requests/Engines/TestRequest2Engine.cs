using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequest2Engine : IRequestEngine<TestRequestWithMultipleEngine, TestResponse>
    {
        public TestResponse Get(TestRequestWithMultipleEngine request)
        {
            return new TestResponse(request.Id);
        }
    }
}