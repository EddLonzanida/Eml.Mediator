﻿using System;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestAsyncRequestWithMultipleEngine : IRequestAsync<TestAsyncRequestWithMultipleEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestAsyncRequestWithMultipleEngine(Guid id)
        {
            Id = id;
        }
    }
}