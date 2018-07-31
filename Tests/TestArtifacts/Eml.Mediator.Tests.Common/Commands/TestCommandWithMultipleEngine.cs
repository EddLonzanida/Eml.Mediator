using Eml.Mediator.Contracts;
{
    public class TestCommandWithMultipleEngine : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithMultipleEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}