﻿using System;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync
{
    public class WhenMakingARequestWithoutEngine : IntegrationTestBase
    {
        [Fact]
        public void Response_ShouldThrowAMissingEngineException()
        {
            var request = new TestRequestWithNoEngine(Guid.NewGuid());

            Should.Throw<MissingEngineException>(() => mediator.Get(request));
        }
    }
}