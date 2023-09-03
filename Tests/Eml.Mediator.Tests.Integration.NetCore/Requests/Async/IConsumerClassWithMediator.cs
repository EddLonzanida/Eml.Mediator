using Eml.Mediator.Tests.Common.Classes;
using Eml.Mediator.Tests.Common.Responses;
using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async;

public interface IConsumerClassWithMediator : IDiDiscoverableTransient
{
    Task<TestResponse> DoSomething();
}
