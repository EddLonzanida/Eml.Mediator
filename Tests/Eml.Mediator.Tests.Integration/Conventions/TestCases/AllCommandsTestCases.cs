using System.Collections;using System.Collections.Generic;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.Helpers;using NUnit.Framework;namespace Eml.Mediator.Tests.Integration.Conventions.TestCases
{
    internal class AllCommandsTestCases : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            return TypeExtensions.GetTestCaseEnumerator<TestCommand>(t => t.IsAssignableTo<ICommand>()
                                                                          && !t.Name.Contains("TestCommandWithNoEngine")
                                                                          && !t.Name.EndsWith("WithMultipleEngine"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
