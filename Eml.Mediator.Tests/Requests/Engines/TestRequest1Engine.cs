using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequest1Engine : IRequestEngine<TestRequestWithMultipleEngine, TestResponse>
    {
        public TestResponse Get(TestRequestWithMultipleEngine request)
        {
            return new TestResponse(request.Id);
        }
    }
}