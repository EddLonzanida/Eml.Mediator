using Eml.Mediator.Contracts;
{
    public class TestCommand : ICommand
    {
        public int EngineInvocationCount { get; set; }

        public TestCommand()
        {
            EngineInvocationCount = 0;
        }
    }
}