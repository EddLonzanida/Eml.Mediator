using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class ConsumerClassWithoutMediator : IDiDiscoverableTransient
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