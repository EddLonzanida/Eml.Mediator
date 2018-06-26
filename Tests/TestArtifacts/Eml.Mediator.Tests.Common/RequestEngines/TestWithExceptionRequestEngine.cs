using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestWithExceptionRequestEngine : IRequestEngine<TestWithExceptionRequest, TestResponse>
    {
        public TestResponse Get(TestWithExceptionRequest request)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}