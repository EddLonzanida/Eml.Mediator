﻿using Eml.Mediator.Contracts;
{
    public class TestAsyncCommandWithException : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}