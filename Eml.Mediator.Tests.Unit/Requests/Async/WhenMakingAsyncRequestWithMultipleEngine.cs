using System;
using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    [TestFixture]
    public class WhenMakingAsyncRequestWithMultipleEngine : UnitTestBase
    {
        [Test]
        public async Task Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestAsyncRequestWithMultipleEngine(Guid.NewGuid());

            await Should.ThrowAsync<MultipleEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}
