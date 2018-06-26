﻿using System;
{
    public class WhenMakingAsyncRequestWithoutEngine : UnitTestBase
    {
        [Test]
        public async Task Response_ShouldThrowMissingEngineException()
        {
            var request = new TestWithNoEngineAsyncRequest(Guid.NewGuid());

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