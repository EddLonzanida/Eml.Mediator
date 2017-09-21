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
        public async Task Response_ShouldThrowMissingEngineException()
        {
            var request = new TestRequestWithNoAsyncEngine(Guid.NewGuid());

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }

        [Test]
        public async Task Response_ShouldThrowMissingEngineExceptionWhenRequestIsOpenGenerics()
        {
            var request = new AutoSuggestAsyncRequest<string>("Test");

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
