﻿using Eml.Mediator.Contracts;
{
    public class TestCommandWithException : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithException()
        {
            EngineInvocationCount = 0;
        }
    }
}