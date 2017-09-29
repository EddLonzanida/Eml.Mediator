﻿using System;
using System.Threading.Tasks;
using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Requests.Async
{
    public class WhenMakingAsyncRequestWithoutEngine : UnitTestBase
    {
        [Fact]
        public async Task Response_ShouldThrowMissingEngineException()
        {
            var request = new TestAsyncRequestWithNoEngine(Guid.NewGuid());

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }

        [Fact]
        public async Task Response_ShouldThrowMissingEngineExceptionWhenRequestIsOpenGenerics()
        {
            var request = new AutoSuggestAsyncRequest<string>("Test");

            await Should.ThrowAsync<MissingEngineException>(async () => await mediator.GetAsync(request));
        }
    }
}