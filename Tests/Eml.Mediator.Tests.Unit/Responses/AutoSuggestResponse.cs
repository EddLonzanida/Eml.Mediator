﻿using System.Collections.Generic;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Unit.Responses
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
