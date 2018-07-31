using Eml.Mediator.Contracts;
{
    public class TestAsyncCommandWithMultipleEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithMultipleEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}