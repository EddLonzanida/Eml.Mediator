using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    public class TestRequestWithExceptionEngine : IRequestEngine<TestRequestWithException, TestResponse>
    {
        public TestResponse Get(TestRequestWithException request)
        {
            throw new System.NotImplementedException();
        }
    }
}