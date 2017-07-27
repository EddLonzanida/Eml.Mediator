using System;
using Eml.Mediator.Extensions;
using Eml.Mediator.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommandThatThrowsException : IntegrationTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            var command = new TestCommandWithException();

            Should.Throw<NotImplementedException>(() => command.Set());
        }
    }
}
