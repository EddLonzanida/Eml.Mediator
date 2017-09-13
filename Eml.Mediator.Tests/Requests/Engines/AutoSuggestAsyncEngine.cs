using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Responses;

namespace Eml.Mediator.Tests.Requests.Engines
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IRequestAsyncEngine<, >))]
    public class AutoSuggestAsyncEngine<T> : IRequestAsyncEngine<AutoSuggestAsyncRequest<T>, AutoSuggestResponse<T>>
    {
        public async Task<AutoSuggestResponse<T>> GetAsync(AutoSuggestAsyncRequest<T> request)
        {
            return await Task.FromResult(new AutoSuggestResponse<T>(new List<T>()));
        }
        public void Dispose()
        {
        }
    }
}
