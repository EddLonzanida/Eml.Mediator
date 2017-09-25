using System;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Commands.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommandThatThrowsException : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldThrowException()
        {
            var command = new TestCommandWithException();

            Should.Throw<NotImplementedException>(() => mediator.Set(command));

            dotMemory.Check(memory => memory
                .GetObjects(where => where.Type.Is<TestCommandWithExceptionEngine>()).ObjectsCount.ShouldBe(0));
        }
    }
}
