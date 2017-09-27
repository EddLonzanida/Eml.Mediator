﻿using Eml.Mediator.Exceptions;
using Eml.Mediator.Tests.Unit.BaseClasses;
using Eml.Mediator.Tests.Unit.Commands.Engines;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Unit.Commands.Sync
{
    [TestFixture]
    public class WhenSendingACommandWithMultipleEngine : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Command_ShouldThrowMultipleEngineException()
        {
            var command = new TestCommandWithMultipleEngine();

            Should.Throw<MultipleEngineException>(() => mediator.Set(command));
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestCommand1Engine>())
                    .ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<TestCommand2Engine>())
                    .ObjectsCount.ShouldBe(0);
            });
        }
    }
}