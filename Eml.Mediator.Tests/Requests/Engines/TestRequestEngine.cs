﻿using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestEngine : IRequestEngine<TestRequest, TestResponse>
    {
        public TestResponse Get(TestRequest request)
        {
            return new TestResponse(request.Id);
        }

        public void Dispose()
        {
        }
    }
}