using System.Collections;
using System.Collections.Generic;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Requests;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Conventions
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
