using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async;

public class ConsumerClassWithoutMediator : IConsumerClassWithoutMediator
{
    private readonly IRequestAsyncHandler<TestAsyncRequest, TestResponse> handler;

    public ConsumerClassWithoutMediator(IRequestAsyncHandler<TestAsyncRequest, TestResponse> handler) //<-Normal dependency injection
    {
        this.handler = handler;
    }

    public async Task<TestResponse> DoSomething()
    {
        var request = new TestAsyncRequest(Guid.CreateVersion7()); //<-Request

        var response = await handler.ExecuteAsync(request); //<-Execute

        return response; //<-Return Value
    }
}
