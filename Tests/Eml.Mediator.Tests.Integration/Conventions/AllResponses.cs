using System;
using Eml.Mediator.Tests.Integration.Conventions.TestCases;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllResponses 
    {
        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllResponses), MemberType = typeof(ConventionsTestCases))]
        public void NameShouldEndWithResponse(Type type)
        {
            type.Name.ShouldEndWith("Response");
        }
    }
}
