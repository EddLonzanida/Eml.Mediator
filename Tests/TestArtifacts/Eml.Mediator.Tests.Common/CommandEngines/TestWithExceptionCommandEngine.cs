using System.ComponentModel.Composition;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.Commands;

namespace Eml.Mediator.Tests.Common.CommandEngines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestWithExceptionCommandEngine : ICommandEngine<TestWithExceptionCommand>
    {
        public void Execute(TestWithExceptionCommand command)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}