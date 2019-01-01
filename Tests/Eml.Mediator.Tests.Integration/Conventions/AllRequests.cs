using System;
using System.Linq;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.Conventions.TestCases;
using Eml.Mediator.Tests.Integration.Helpers;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllRequests
    {
        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllRequests), MemberType = typeof(ConventionsTestCases))]
        public void MustHaveExactlyOneEngine(Type requestType)
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
        }

        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllRequests), MemberType = typeof(ConventionsTestCases))]
        public void NameShouldEndWithRequest(Type type)
        {
            type.Name.ShouldEndWith("Request");
        }

        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllAsyncRequests), MemberType = typeof(ConventionsTestCases))]
        public void NameShouldEndWithAsyncRequest(Type type)
        {
            type.Name.ShouldEndWith("AsyncRequest");
        }
    }
}