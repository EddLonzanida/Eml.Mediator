using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequestEngine : IRequestEngine<TestRequest, TestResponse>
    {
        public TestResponse Get(TestRequest request)
        {
            return new TestResponse(request.Id);
        }
    }
}