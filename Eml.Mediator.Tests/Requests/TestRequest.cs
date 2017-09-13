﻿using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequest : IRequest<TestRequest, TestResponse>
    {
        public Guid Id { get; private set; }

        public TestRequest(Guid id)
        {
            Id = id;
        }
    }
}