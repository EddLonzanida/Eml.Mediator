using System.Collections;
using System.Collections.Generic;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Commands;
using Eml.Mediator.Tests.Helpers;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Conventions.TestCases
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