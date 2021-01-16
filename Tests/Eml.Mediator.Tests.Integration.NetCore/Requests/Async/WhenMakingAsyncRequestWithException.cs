using System;using System.Threading.Tasks;using Eml.Mediator.Tests.Common.Requests;using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async
{
    public class WhenMakingAsyncRequestWithException : IntegrationTestDiBase
    {
        [Fact]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestAsyncRequestWithException(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.ExecuteAsync(request));
        }
    }
}
