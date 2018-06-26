using System;
using Eml.Mediator.Tests.Common.CommandEngines;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Integration.BaseClasses;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Commands.Sync
{
    public class WhenSendingACommandWithException : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldThrowException()
        {
            var command = new TestWithExceptionCommand();

            Should.Throw<NotImplementedException>(() => mediator.Set(command));

            dotMemory.Check(memory => memory
                .GetObjects(where => where.Type.Is<TestWithExceptionCommandEngine>()).ObjectsCount.ShouldBe(0));
        }
    }
}
