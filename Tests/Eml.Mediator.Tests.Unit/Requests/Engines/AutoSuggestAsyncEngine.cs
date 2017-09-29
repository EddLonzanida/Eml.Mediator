#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using Eml.ClassFactory.Contracts;
#endif

using System.Collections.Generic;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using Eml.Mediator.Tests.Unit.Responses;

namespace Eml.Mediator.Tests.Unit.Requests.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
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
