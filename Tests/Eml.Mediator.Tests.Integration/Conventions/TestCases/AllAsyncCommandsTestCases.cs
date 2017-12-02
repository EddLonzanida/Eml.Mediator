using System.Collections;using System.Collections.Generic;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Common.Commands;using Eml.Mediator.Tests.Integration.Helpers;using NUnit.Framework;namespace Eml.Mediator.Tests.Integration.Conventions.TestCases
{
    internal class AllAsyncCommandsTestCases : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            return TypeExtensions.GetTestCaseEnumerator<TestAsyncCommand>(t => t.IsAssignableTo<ICommandAsync>()
                                                                               && !t.Name.Contains("TestAsyncCommandWithNoEngine")
                                                                               && !t.Name.EndsWith("TestAsyncCommandWithMultipleEngine"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}