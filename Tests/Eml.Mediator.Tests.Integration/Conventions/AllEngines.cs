using System;
using System.ComponentModel.Composition;
using System.Linq;
using Eml.Mediator.Tests.Integration.Conventions.TestCases;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllEngines
    {
        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllCommandEngines), MemberType = typeof(ConventionsTestCases))]
        [MemberData(nameof(ConventionsTestCases.GetAllRequestEngines), MemberType = typeof(ConventionsTestCases))]
        [MemberData(nameof(ConventionsTestCases.GetAllCommandAsyncEngines), MemberType = typeof(ConventionsTestCases))]
        [MemberData(nameof(ConventionsTestCases.GetAllRequestAsyncEngines), MemberType = typeof(ConventionsTestCases))]
        public void ShouldHaveNonSharedAttribute(Type exportedType)
        {
            var partCreationPolicyAttribute = exportedType
                .GetCustomAttributes(typeof(PartCreationPolicyAttribute), true)
                .FirstOrDefault();

            var creationPolicyAttribute = partCreationPolicyAttribute as PartCreationPolicyAttribute;

            creationPolicyAttribute.ShouldNotBeNull();
            creationPolicyAttribute.CreationPolicy.ShouldBe(CreationPolicy.NonShared);
        }
    }
}
