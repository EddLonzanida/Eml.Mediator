using System;
using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Requests.Async
{
    [TestFixture]
    public class WhenMakingAnAsyncRequestWithMultipleEngine : IntegrationTestBase
    {
        [Test]
        public async Task ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleAsyncEngine(Guid.NewGuid());

            await Should.ThrowAsync<MultipleEngineException>(async () => await request.GetAsync());
        }
    }
}
