#if NETFULLusing System.ComponentModel.Composition;#endif#if NETCOREusing Eml.ClassFactory.Contracts;#endifusing Eml.Mediator.Contracts;using Eml.Mediator.Tests.Integration.NetCore.Responses;namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
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