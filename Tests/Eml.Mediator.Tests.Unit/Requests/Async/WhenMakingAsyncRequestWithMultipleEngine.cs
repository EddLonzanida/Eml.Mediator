using System;
using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    public class WhenMakingAsyncRequestWithMultipleEngine : UnitTestBase
    {
        [Fact]
        public async Task Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestAsyncRequestWithMultipleEngine(Guid.NewGuid());

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
