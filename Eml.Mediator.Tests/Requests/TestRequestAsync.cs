using System;
using Eml.Mediator.Contracts;

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