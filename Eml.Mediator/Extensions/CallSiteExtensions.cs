using Eml.Mediator.Contracts;
using System.Runtime.CompilerServices;

namespace Eml.Mediator.Extensions;

public static class CallSiteExtensions
{
    /// <summary>
    ///     <para>IF <paramref name="callSiteFromHigherStack" /> is supplied, the rest will be ignored.</para>
    /// </summary>
    public static string ToCallSite<T>(this T? callee,
        string? callSiteFromHigherStack = null,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
        where T : class, IEngine
    {
        if (!string.IsNullOrWhiteSpace(callSiteFromHigherStack))
        {
            return callSiteFromHigherStack;
        }

        var objTypeName = callee?.GetType().FullName
                          ?? typeof(T).FullName
                          ?? string.Empty;

        var callSite = $"{callerFilePath}:line {callerLineNumber:N0} → {objTypeName}";

        return callSite;
    }

    public static string ToCallSite(this string? methodThatWasCalled,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0)
    {
        var callSite = $"{callerFilePath}:line {callerLineNumber:N0} → {methodThatWasCalled}";

        return callSite;
    }
}
