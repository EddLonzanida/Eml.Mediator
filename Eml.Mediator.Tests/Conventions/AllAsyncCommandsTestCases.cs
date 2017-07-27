using System.Collections;
using System.Collections.Generic;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Commands;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Conventions
{
    internal class AllAsyncCommandsTestCases : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            return TypeExtensions.GetTestCaseEnumerator<TestCommandAsync>(t => t.IsAssignableTo<ICommandAsync>()
                                                                               && !t.Name.Contains("TestCommandWithNoAsyncEngine")
                                                                               && !t.Name.EndsWith("TestCommandWithMultipleAsyncEngine"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}