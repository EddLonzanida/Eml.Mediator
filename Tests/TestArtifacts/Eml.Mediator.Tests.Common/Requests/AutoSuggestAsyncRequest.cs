﻿using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Requests
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