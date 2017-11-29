using System;
using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Async
{
    public class WhenMakingAsyncRequestWithMultipleEngine : IntegrationTestBase
    {
        [Fact]
        public async Task Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestAsyncRequestWithMultipleEngine(Guid.NewGuid());

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
