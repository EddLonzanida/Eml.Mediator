using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class ConsumerClassWithoutMediator : IConsumerClassWithoutMediator
    {
        private readonly IRequestAsyncEngine<TestAsyncRequest, TestResponse> engine;

        public ConsumerClassWithoutMediator(IRequestAsyncEngine<TestAsyncRequest, TestResponse> engine)     //<-Normal dependency injection
        {
            this.engine = engine;
        }

        public async Task<TestResponse> DoSomething()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());     //<-Request

            var response = await engine.ExecuteAsync(request);      //<-Execute

            return response;                                        //<-Return Value
        }
    }
}