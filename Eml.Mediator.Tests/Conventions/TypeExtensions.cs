using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Eml.Mediator.Tests.Conventions
{
    public static class TypeExtensions
    {
        public static bool IsInstantiable(this Type type)
        {
            if (type.IsInterface) return false;
            if (type.IsAbstract) return false;
            return !type.ContainsGenericParameters;
        }

        public static bool IsAssignableTo<TTarget>(this Type type)
        {
            return typeof(TTarget).IsAssignableFrom(type);
        }

        /// <summary>
        ///     Alias for IsAssignableTo.
        /// </summary>
        /// <remarks>
        ///     This alias is to avoid collisions with Autofac's extension method of the same name.
        /// </remarks>
        public static bool CanBeAssignedTo<TTarget>(this Type type)
        {
            return IsAssignableTo<TTarget>(type);
        }

        public static bool IsClosedTypeOf(this Type type, Type openGenericType)
        {
            if (!openGenericType.IsGenericType) throw new ArgumentException("It's a bit difficult to have a closed type of a non-open-generic type", "openGenericType");

            var interfaces = type.GetInterfaces();
            var baseTypes = new[] { type }.DepthFirst(t => t.BaseType == null ? new Type[0] : new[] { t.BaseType });
            var typeAndAllThatThatEntails = new[] { type }.Union(interfaces).Union(baseTypes).ToArray();
            var genericTypes = typeAndAllThatThatEntails.Where(i => i.IsGenericType);
            var closedGenericTypes = genericTypes.Where(i => !i.IsGenericTypeDefinition);
            var assignableGenericTypes = closedGenericTypes.Where(i => openGenericType.IsAssignableFrom(i.GetGenericTypeDefinition()));

            return assignableGenericTypes.Any();
        }

        public static bool IsClosedTypeOf(this Type type, params Type[] openGenericTypes)
        {
            return openGenericTypes.Any(type.IsClosedTypeOf);
        }

        public static Type[] GetGenericInterfacesClosing(this Type type, Type genericInterface)
        {
            var genericInterfaces = type.GetInterfaces()
                .Where(i => i.IsClosedTypeOf(genericInterface))
                .ToArray();
            return genericInterfaces;
        }


        public static IEnumerable<T> DepthFirst<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> children)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var descendant in children(item).DepthFirst(children)) yield return descendant;
            }
        }

        public static IEnumerator<TestCaseData> GetTestCaseEnumerator<T>(Func<TypeInfo, bool> predicate)
            where T : class
        {
            return typeof(T).Assembly
                .DefinedTypes
                .Where(t => t.IsInstantiable())
                .Where(predicate)
                .Select(t => new TestCaseData(t))
                .GetEnumerator();
        }
    }
}
