﻿using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using System;

namespace Eml.Mediator.Tests.Common.RequestEngines;

public class TestRequestWithExceptionEngine : IRequestEngine<TestRequestWithException, TestResponse>
{
    public TestResponse Execute(TestRequestWithException request)
    {
        throw new NotImplementedException();
    }
}
