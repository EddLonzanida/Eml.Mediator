using Eml.Mediator.Contracts;
{
    public class TestCommandWithNoEngine : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandWithNoEngine()
        {
            EngineInvocationCount = 0;
        }
    }
}