using System;
using System.ComponentModel.Composition;
using System.Linq;
using Eml.Mediator.Tests.Conventions.TestCases;
using NUnit.Framework;
using Shouldly;

namespace Eml.Mediator.Tests.Conventions
{
    public class AllEngines
    {
        [Test]
        [TestCaseSource(typeof(AllExportsTestCases))]
        public void ShouldHaveNonSharedAttribute(Type exportedType)
        {
            var partCreationPolicyAttribute = exportedType
                .GetCustomAttributes(typeof(PartCreationPolicyAttribute), true)
                .FirstOrDefault();

            partCreationPolicyAttribute.ShouldNotBeNull();

            var creationPolicyAttribute = partCreationPolicyAttribute as PartCreationPolicyAttribute;
            creationPolicyAttribute?.CreationPolicy.ShouldBe(CreationPolicy.NonShared);
        }
    }
}
