using System;using System.Linq;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Integration.Conventions.TestCases;using Eml.Mediator.Tests.Integration.Helpers;using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllRequests
    {
        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllRequests))]
        public void MustHaveACorrespondingEngine(Type requestType)
        {
            var typeArguments = requestType
                .GetInterfaces()
                .Single(i => i.IsClosedTypeOf(typeof(IRequest<,>)))
                .GetGenericArguments();

            var engineInterfaceType = typeof(IRequestEngine<,>).MakeGenericType(typeArguments);

            var engineTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => engineInterfaceType.IsAssignableFrom(t))
                .ToArray();

            engineTypes.Length.ShouldBe(1);
            engineTypes.First().Name.ShouldBe(requestType.Name + "Engine");
        }

        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllAsyncRequests))]
        public void MustHaveACorrespondingAsyncEngine(Type requestType)
        {
            var typeArguments = requestType
                .GetInterfaces()
                .Single(i => i.IsClosedTypeOf(typeof(IRequestAsync<,>)))
                .GetGenericArguments();

            var engineInterfaceType = typeof(IRequestAsyncEngine<,>).MakeGenericType(typeArguments);

            var engineTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => engineInterfaceType.IsAssignableFrom(t))
                .ToArray();

            engineTypes.Length.ShouldBe(1);
            engineTypes.First().Name.ShouldBe(requestType.Name + "Engine");
        }

        [Theory]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllRequests))]
        public void NameShouldEndWithRequest(Type type)
        {
            type.Name.ShouldEndWith("Request");
        }

        [Theory]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllAsyncRequests))]
        public void NameShouldEndWithAsyncRequest(Type type)
        {
            type.Name.ShouldEndWith("AsyncRequest");
        }
    }
}