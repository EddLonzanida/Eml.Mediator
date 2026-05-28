using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Common.RequestHandlers;
using Eml.Mediator.Tests.Common.Responses;

namespace Eml.Mediator.Tests.Common.Requests;

public class AutoSuggestAsyncRequest<T>
    : IRequestAsync<AutoSuggestAsyncRequest<T>, AutoSuggestResponse<T>>
{
    public string? CallSite { get; set; }

    public string SearchTerm { get; }

    /// <summary>
    ///     This request will be processed by <see cref="AutoSuggestAsyncHandler{T}" />.
    /// </summary>
    public AutoSuggestAsyncRequest(string searchTerm)
    {
        SearchTerm = searchTerm;
    }
}
