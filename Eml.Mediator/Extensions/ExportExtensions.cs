#if NETFULL
using System;
#endif
#if NETCORE
using System.Composition;
#endif

namespace Eml.Mediator.Extensions
{
    public static class ExportExtensions
    {
#if NETFULL
        public static T Instance<T>(this Lazy<T> lazy)
        {
            return lazy.Value;
        }
#endif
#if NETCORE
        public static T Instance<T>(this ExportFactory<T> lazy)
        {
            return lazy.CreateExport().Value;
        }
#endif
    }
}
