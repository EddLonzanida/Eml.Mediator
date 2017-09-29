using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests
{
    public class AutoSuggestAsyncRequest<T> 
        : IRequestAsync<AutoSuggestAsyncRequest<T>, AutoSuggestResponse<T>>
    {
        public string SearchTerm { get; }
        public AutoSuggestAsyncRequest(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}
