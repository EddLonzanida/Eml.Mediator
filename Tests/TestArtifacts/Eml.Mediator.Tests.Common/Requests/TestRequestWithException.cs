﻿using System;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestRequestWithException : IRequest<TestRequestWithException, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithException(Guid id)
        {
            Id = id;
        }
    }
}