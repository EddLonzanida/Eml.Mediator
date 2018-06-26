﻿using System;
{
    public class WhenMakingARequestWithException : UnitTestBase
    {
        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Response_ShouldThrowException()
        {
            var request = new TestWithExceptionRequest(Guid.NewGuid());

            Should.Throw<NotImplementedException>(() => mediator.Get(request));

            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<TestWithExceptionRequestEngine>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}