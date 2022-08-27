using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestEngines;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests;

public class AutoSuggestAsyncRequest<T>
    : IRequestAsync<AutoSuggestAsyncRequest<T>, AutoSuggestResponse<T>>
{
    public string SearchTerm { get; }

    /// <summary>
    ///     This request will be processed by <see cref="AutoSuggestAsyncEngine{T}" />.
    /// </summary>
    public AutoSuggestAsyncRequest(string searchTerm)
    {
        SearchTerm = searchTerm;
    }
}
