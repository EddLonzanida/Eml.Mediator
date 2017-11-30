using System;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Common.RequestEngines;

namespace Eml.Mediator.Tests.Common.Requests
{
    /// <summary>
    /// This request will be processed by <see cref="TestRequestAsyncEngine"/> .
    /// </summary>
    public class TestAsyncRequest : IRequestAsync<TestAsyncRequest, TestResponse>
    {
        public Guid Id { get; private set; }

        public TestAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}