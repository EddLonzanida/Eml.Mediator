using System;
using System.Linq;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.Conventions.TestCases;
using Xunit;
using Shouldly;

namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllCommands 
    {
        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllCommands), MemberType = typeof(ConventionsTestCases))]
        public void MustHaveACorrespondingEngine(Type commandType)
        {
            var syncEngineInterfaceType = typeof(ICommandEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => syncEngineInterfaceType.IsAssignableFrom(t) )
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.First().Name.ShouldEndWith("Engine");
        }

        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllAsyncCommands), MemberType = typeof(ConventionsTestCases))]
        public void MustHaveACorrespondingAsyncEngine(Type commandType)
        {
            var asyncEngineInterfaceType = typeof(ICommandAsyncEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => asyncEngineInterfaceType.IsAssignableFrom(t))
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.First().Name.ShouldEndWith("Engine");
        }

        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllAsyncCommands), MemberType = typeof(ConventionsTestCases))]
        public void NameShouldEndWithAsyncCommand(Type type)
        {
            type.Name.ShouldEndWith("AsyncCommand");
        }

        [Theory]
        [MemberData(nameof(ConventionsTestCases.GetAllCommands), MemberType = typeof(ConventionsTestCases))]
        public void NameShouldEndWithCommand(Type type)
        {
            type.Name.ShouldEndWith("Command");
        }
    }
}