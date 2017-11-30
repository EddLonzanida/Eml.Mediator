﻿using System;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestAsyncRequestWithException : IRequestAsync<TestAsyncRequestWithException, TestResponse>
    {
        public Guid Id { get; }

        public TestAsyncRequestWithException(Guid id)
        {
            Id = id;
        }
    }
}