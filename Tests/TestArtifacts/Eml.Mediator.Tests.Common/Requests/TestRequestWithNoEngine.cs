﻿using System;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestRequestWithNoEngine : IRequest<TestRequestWithNoEngine, TestResponse>
    {
        public Guid Id { get; }

        public TestRequestWithNoEngine(Guid id)
        {
            Id = id;
        }
    }
}