using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Sync
{
    public class WhenMakingARequestWithMultipleEngine : UnitTestBase
    {
        [Fact]
        public void Response_ShouldThrowMultipleEngineException()
        {
            var request = new TestRequestWithMultipleEngine(Guid.NewGuid());

            Should.Throw<MultipleEngineException>(() => mediator.Get(request));
        }
    }
}
