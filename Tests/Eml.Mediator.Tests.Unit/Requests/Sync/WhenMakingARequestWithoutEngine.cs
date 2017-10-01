using System;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Sync
{
    public class WhenMakingARequestWithoutEngine : UnitTestBase
    {
        [Fact]
        public void Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestRequestWithNoEngine(Guid.NewGuid());

            Should.Throw<MissingEngineException>(() => mediator.Get(request));
        }
    }
}
