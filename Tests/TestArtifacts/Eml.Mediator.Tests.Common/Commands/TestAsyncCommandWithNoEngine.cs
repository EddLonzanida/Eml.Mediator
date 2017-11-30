using Eml.Mediator.Contracts;
{
    public class TestAsyncCommandWithNoEngine : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestAsyncCommandWithNoEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}