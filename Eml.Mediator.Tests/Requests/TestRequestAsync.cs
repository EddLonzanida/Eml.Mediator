using System;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests
{
    public class TestRequestAsync : IRequestAsync<TestRequestAsync, TestResponse>
    {
        public Guid Id { get; private set; }

        public TestRequestAsync(Guid id)
        {
            Id = id;
        }
    }
}