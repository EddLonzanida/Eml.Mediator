﻿using System.Collections.Generic;
{
    public class AutoSuggestResponse<T> : IResponse
    {
        public IEnumerable<T> Suggestions { get; }

        public AutoSuggestResponse(IEnumerable<T> suggestions)
        {
            Suggestions = suggestions;
        }
    }
}