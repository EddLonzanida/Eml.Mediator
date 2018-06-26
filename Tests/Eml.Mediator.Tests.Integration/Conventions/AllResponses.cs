using System;
using Eml.Mediator.Tests.Integration.Conventions.TestCases;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllResponses
    {
        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllResponses))]
        public void NameShouldEndWithResponse(Type type)
        {
            type.Name.ShouldEndWith("Response");
        }
    }
}
