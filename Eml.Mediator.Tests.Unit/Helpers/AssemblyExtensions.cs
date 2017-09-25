﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Eml.Mediator.Tests.Unit.Helpers
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Assembly> GetAssembliesFromDirectory(this DirectoryInfo directory, string filePattern)
        {
            var assemblies = new List<Assembly>();
            var files = Directory.GetFiles(directory.FullName, filePattern).ToList();
            files.ForEach(r => assemblies.Add(Assembly.LoadFile(r)));
            return assemblies;
        }

        public static IEnumerable<Type> GetClasses(this Assembly assembly, Func<Type, bool> selector)
        {
            return assembly.GetTypes(type => !type.IsAbstract && selector(type));
        }

        private static IEnumerable<Type> GetTypes(this Assembly assembly, Func<Type, bool> selector)
        {
            var types = assembly.GetTypes();
            return types.Where(type => selector(type) && type.IsPublic);
        }
    }
}
