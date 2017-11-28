using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Integration.NetCore.Responses;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests
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
