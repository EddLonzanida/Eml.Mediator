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
    public class WhenMakingAnAsyncRequestWithoutEngine : IntegrationTestBase
    {
        [Test]
        public async Task Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestRequestWithNoAsyncEngine(Guid.NewGuid());

            await Should.ThrowAsync<MissingEngineException>(async () => await request.GetAsync());
        }
    }
}
