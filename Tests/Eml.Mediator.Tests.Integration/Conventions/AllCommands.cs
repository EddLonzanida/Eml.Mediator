using System;using System.Linq;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Integration.Conventions.TestCases;using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllCommands
    {
        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllCommands))]
        public void MustHaveACorrespondingEngine(Type commandType)
        {
            var syncEngineInterfaceType = typeof(ICommandEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => syncEngineInterfaceType.IsAssignableFrom(t))
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.First().Name.ShouldBe(commandType.Name + "Engine");
        }

        [Test]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllAsyncCommands))]
        public void MustHaveACorrespondingAsyncEngine(Type commandType)
        {
            var asyncEngineInterfaceType = typeof(ICommandAsyncEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => asyncEngineInterfaceType.IsAssignableFrom(t))
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.First().Name.ShouldBe(commandType.Name + "Engine");
        }

        [Theory]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllAsyncCommands))]
        public void NameShouldEndWithAsyncCommand(Type type)
        {
            type.Name.ShouldEndWith("AsyncCommand");
        }

        [Theory]
        [TestCaseSource(typeof(ConventionsTestCases), nameof(ConventionsTestCases.GetAllCommands))]
        public void NameShouldEndWithCommand(Type type)
        {
            type.Name.ShouldEndWith("Command");
        }
    }
}