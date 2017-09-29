using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    public class WhenMakingAsyncRequestWithException : UnitTestBase
    {
        [Fact]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestAsyncRequestWithException(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.GetAsync(request));
        }
    }
}
