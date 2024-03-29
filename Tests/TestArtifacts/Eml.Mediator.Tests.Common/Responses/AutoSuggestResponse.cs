﻿using Eml.Mediator.Contracts;
using System.Collections.Generic;

namespace Eml.Mediator.Tests.Common.Responses;

public class AutoSuggestResponse<T> : IResponse
{
    public IEnumerable<T> Suggestions { get; }

    public AutoSuggestResponse(IEnumerable<T> suggestions)
    {
        Suggestions = suggestions;
    }
}
