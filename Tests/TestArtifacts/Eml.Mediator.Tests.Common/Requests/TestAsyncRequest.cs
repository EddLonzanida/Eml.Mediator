using System;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Common.RequestEngines;

namespace Eml.Mediator.Tests.Common.Requests
{
    public class TestAsyncRequest : IRequestAsync<TestAsyncRequest, TestResponse>
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// This request will be processed by <see cref="TestRequestAsyncEngine"/>.
        /// </summary>
        public TestAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
}