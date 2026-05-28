using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.RequestHandlers;

public class TestRequest1Handler : IRequestHandler<TestRequestWithMultipleHandler, TestResponse>
{
    public TestResponse Execute(TestRequestWithMultipleHandler request)
    {
        return new TestResponse(request.Id);
    }
}
