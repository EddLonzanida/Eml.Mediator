using System;
using System.Threading.Tasks;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Async
{
    [TestFixture]
    public class WhenMakingAnAsyncRequestThatThrowsException : IntegrationTestBase
    {
        [Test]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestRequestAsyncWithException(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await request.GetAsync());
        }
    }
}
