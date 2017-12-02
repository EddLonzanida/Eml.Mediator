using System;
using System.Threading.Tasks;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.BaseClasses;
using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Requests.Async
{
    public class WhenMakingAsyncRequestWithException : UnitTestBase
    {
        [Test]
        public async Task Response_ShouldThrowException()
        {
            var request = new TestAsyncRequestWithException(Guid.NewGuid());

            await Should.ThrowAsync<NotImplementedException>(async () => await mediator.GetAsync(request));
        }
    }
}
