using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequest1Engine : IRequestEngine<TestRequestWithMultipleEngine, TestResponse>
    {
        public TestResponse Get(TestRequestWithMultipleEngine request)
        {
            return new TestResponse(request.Id);
        }
    }
}