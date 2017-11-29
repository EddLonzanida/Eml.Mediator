﻿using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.NetFull.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetFull.Requests.Async
{
    public class WhenMakingAsyncRequestWithException : IntegrationTestBase
    {
        [Fact]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestAsyncRequestWithException(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.GetAsync(request));
        }
    }
}
