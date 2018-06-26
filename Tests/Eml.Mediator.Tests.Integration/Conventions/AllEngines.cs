﻿using System;
{
    public class AllEngines
    {
        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllCommandEngines))]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllRequestEngines))]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllCommandAsyncEngines))]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllRequestAsyncEngines))]
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