#if NETFULLusing System.ComponentModel.Composition;#endif#if NETCOREusing Eml.ClassFactory.Contracts;#endifusing Eml.Mediator.Contracts;using Eml.Mediator.Tests.Integration.NetCore.Responses;namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestRequestWithExceptionEngine : IRequestEngine<TestRequestWithException, TestResponse>
    {
        public TestResponse Get(TestRequestWithException request)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}