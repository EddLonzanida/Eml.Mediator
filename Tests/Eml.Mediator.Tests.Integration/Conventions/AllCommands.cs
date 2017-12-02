using System;using System.Linq;using Eml.Mediator.Contracts;using Eml.Mediator.Tests.Integration.Conventions.TestCases;using NUnit.Framework;using Shouldly;namespace Eml.Mediator.Tests.Integration.Conventions
{
    public class AllCommands
    {
        [Test]
        [TestCaseSource(typeof(AllCommandsTestCases))]
        public void MustHaveExactlyTwoEngine(Type commandType)
        {
            var syncEngineInterfaceType = typeof(ICommandEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => syncEngineInterfaceType.IsAssignableFrom(t))
                .ToArray();

            engineTypes.Length.ShouldBe(1);
        }

        [Test]
        [TestCaseSource(typeof(AllAsyncCommandsTestCases))]
        public void MustHaveExactlyTwoAsyncEngine(Type commandType)
        {
            var asyncEngineInterfaceType = typeof(ICommandAsyncEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => asyncEngineInterfaceType.IsAssignableFrom(t))
                .ToArray();

            engineTypes.Length.ShouldBe(1);
        }

        [Test]
        [TestCaseSource(typeof(AllCommandsTestCases))]
        public void MustHaveACorrespondingEngine(Type commandType)
        {
            var syncEngineInterfaceType = typeof(ICommandEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => syncEngineInterfaceType.IsAssignableFrom(t) )
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.TrueForAll(r => r.Name.StartsWith(commandType.Name) && r.Name.EndsWith("Engine"))
                .ShouldBe(true);
        }

        [Test]
        [TestCaseSource(typeof(AllAsyncCommandsTestCases))]
        public void MustHaveACorrespondingAsyncEngine(Type commandType)
        {
            var asyncEngineInterfaceType = typeof(ICommandAsyncEngine<>).MakeGenericType(commandType);

            var engineTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.DefinedTypes)
                .Where(t => asyncEngineInterfaceType.IsAssignableFrom(t))
                .ToList();

            engineTypes.Count.ShouldBe(1);
            engineTypes.TrueForAll(r => r.Name.StartsWith(commandType.Name) && r.Name.EndsWith("Engine"))
                .ShouldBe(true);
        }
    }
}