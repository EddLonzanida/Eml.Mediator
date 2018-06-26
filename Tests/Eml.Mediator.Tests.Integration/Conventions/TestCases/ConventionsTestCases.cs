using System.Collections.Generic;
using System.Linq;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common;
using Eml.Mediator.Tests.Common.Commands;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Integration.Helpers;

namespace Eml.Mediator.Tests.Integration.Conventions.TestCases
{
    public class ConventionsTestCases
    {
        private static IEnumerable<object[]> _allAsyncCommands;

        public static IEnumerable<object[]> GetAllAsyncCommands()
        {
            if (_allAsyncCommands == null)
            {

                _allAsyncCommands = TypeExtensions
                .GetTestCaseEnumerable<TestCommand>(t => t.IsAssignableTo<ICommandAsync>()
                                                                  && !t.Name.EndsWith(nameof(TestAsyncCommandWithNoEngine))
                                                                  && !t.Name.EndsWith(nameof(TestAsyncCommandWithMultipleEngine)))
                .Select(x => new object[] { x });
            }

            return _allAsyncCommands;
        }

        private static IEnumerable<object[]> _allAsyncRequests;

        public static IEnumerable<object[]> GetAllAsyncRequests()
        {
            if (_allAsyncRequests == null)
                _allAsyncRequests = TypeExtensions
                .GetTestCaseEnumerable<AssemblyMarker>(t =>
                    t.IsClosedTypeOf(typeof(IRequestAsync<,>))
                    && !t.Name.EndsWith(nameof(TestWithNoEngineAsyncRequest))
                    && !t.Name.EndsWith(nameof(TestWithMultipleEngineAsyncRequest)))
                .Select(x => new object[] { x });

            return _allAsyncRequests;
        }

        private static IEnumerable<object[]> _allRequests;

        public static IEnumerable<object[]> GetAllRequests()
        {
            if (_allRequests == null)
                _allRequests = TypeExtensions
                                .GetTestCaseEnumerable<AssemblyMarker>(t =>
                                    t.IsClosedTypeOf(typeof(IRequest<,>))
                                    && !t.Name.EndsWith(nameof(TestWithNoEngineRequest))
                                    && !t.Name.EndsWith(nameof(TestWithMultipleEngineRequest)))
                .Select(x => new object[] { x });

            return _allRequests;
        }

        private static IEnumerable<object[]> _allCommands;

        public static IEnumerable<object[]> GetAllCommands()
        {
            if (_allCommands == null)
                _allCommands = TypeExtensions
                                .GetTestCaseEnumerable<TestCommand>(t =>
                                    t.IsAssignableTo<ICommand>()
                                    && !t.Name.Contains(nameof(TestCommandWithNoEngine))
                                    && !t.Name.EndsWith(nameof(TestCommandWithMultipleEngine)))
                                .Select(x => new object[] { x });

            return _allCommands;
        }

        private static IEnumerable<object[]> _allResponses;

        public static IEnumerable<object[]> GetAllResponses()
        {
            if (_allResponses == null)
                _allResponses = TypeExtensions
                                .GetTestCaseEnumerable<AssemblyMarker>(t => t.IsAssignableTo<IResponse>())
                                .Select(x => new object[] { x });

            return _allResponses;
        }

        private static IEnumerable<object[]> _allCommandEngines;

        public static IEnumerable<object[]> GetAllCommandEngines()
        {
            if (_allCommandEngines == null)
                _allCommandEngines = TypeExtensions
                                    .GetTestCaseEnumerable<AssemblyMarker>(t => t.IsClosedTypeOf(typeof(ICommandEngine<>)))
                                    .Select(x => new object[] { x });

            return _allCommandEngines;
        }

        private static IEnumerable<object[]> _allCommandAsyncEngines;

        public static IEnumerable<object[]> GetAllCommandAsyncEngines()
        {
            if (_allCommandAsyncEngines == null)
                _allCommandAsyncEngines = TypeExtensions
                                          .GetTestCaseEnumerable<AssemblyMarker>(t => t.IsClosedTypeOf(typeof(ICommandAsyncEngine<>)))
                                          .Select(x => new object[] { x });

            return _allCommandAsyncEngines;
        }

        private static IEnumerable<object[]> _allRequestEngines;

        public static IEnumerable<object[]> GetAllRequestEngines()
        {
            if (_allRequestEngines == null)
                _allRequestEngines = TypeExtensions
                                    .GetTestCaseEnumerable<AssemblyMarker>(t => t.IsClosedTypeOf(typeof(IRequestEngine<,>)))
                                    .Select(x => new object[] { x });

            return _allRequestEngines;
        }

        private static IEnumerable<object[]> _allRequestAsyncEngines;

        public static IEnumerable<object[]> GetAllRequestAsyncEngines()
        {
            if (_allRequestAsyncEngines == null)
                _allRequestAsyncEngines = TypeExtensions
                                         .GetTestCaseEnumerable<AssemblyMarker>(t => t.IsClosedTypeOf(typeof(IRequestAsyncEngine<,>)))
                                         .Select(x => new object[] { x });

            return _allRequestAsyncEngines;
        }
    }
}
