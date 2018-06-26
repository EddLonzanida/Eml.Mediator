using System;using System.Collections.Generic;using System.ComponentModel.Composition;using System.Linq;using System.Reflection;using NUnit.Framework;namespace Eml.Mediator.Tests.Integration.Helpers
{
    public static class TypeExtensions
    {
        public static bool IsAssignableTo<TTarget>(this Type type)
        {
            return typeof(TTarget).IsAssignableFrom(type);
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

        public static IEnumerable<T> DepthFirst<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> children)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var descendant in children(item).DepthFirst(children)) yield return descendant;
            }
        }

        public static IEnumerable<Type> GetTestCaseEnumerable<TAssembly>(Func<TypeInfo, bool> predicate)
            where TAssembly : class
        {
            return typeof(TAssembly).Assembly
                .DefinedTypes
                .Where(t => t.IsInstantiable())
                .Where(predicate);
        }

        public static bool IsInstantiable(this Type type)
        {
            if (type.IsInterface) return false;
            if (type.IsAbstract) return false;
            return !type.ContainsGenericParameters;
        }
        public static bool IsExportable(this Type type)
        {
            return type.GetCustomAttribute(typeof(ExportAttribute), true) != null;
        }
    }
}
