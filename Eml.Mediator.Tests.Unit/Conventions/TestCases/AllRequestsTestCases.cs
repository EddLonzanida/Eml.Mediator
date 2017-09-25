using System.Collections;
using System.Collections.Generic;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Helpers;
using Eml.Mediator.Tests.Unit.Requests;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Unit.Conventions.TestCases
{
    internal class AllRequestsTestCases : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            return TypeExtensions.GetTestCaseEnumerator<TestRequest> (t => t.IsClosedTypeOf(typeof(IRequest<,>)) 
                                                         && !t.Name.Contains("TestRequestWithNoEngine") 
                                                         && !t.Name.EndsWith("WithMultipleEngine"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
