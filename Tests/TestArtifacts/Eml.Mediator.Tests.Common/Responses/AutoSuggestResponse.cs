using Eml.Mediator.Contracts;
using System.Collections.Generic;

namespace Eml.Mediator.Tests.Common.Responses;

public class AutoSuggestResponse<T>(IEnumerable<T> suggestions) : IResponse
{
    public IEnumerable<T> Suggestions { get; } = suggestions;
}
