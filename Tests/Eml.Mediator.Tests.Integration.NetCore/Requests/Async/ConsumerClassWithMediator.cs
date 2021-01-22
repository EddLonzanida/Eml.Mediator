using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Classes;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class ConsumerClassWithMediator : IDiDiscoverableTransient
    {
        private readonly IMediator mediator;

        public ConsumerClassWithMediator(IMediator mediator)        //<-Inject IMediator
        {
            this.mediator = mediator;
        }

        public async Task<TestResponse> DoSomething()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());     //<-Request

            var response = await mediator.ExecuteAsync(request);    //<-Execute

            return response;                                        //<-Return Value
        }
    }
}