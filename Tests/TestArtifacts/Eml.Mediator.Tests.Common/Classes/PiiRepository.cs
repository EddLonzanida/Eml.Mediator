#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using System.Composition;
#endif

using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.Classes
{
    [Export(typeof(IPiiRepository<>))]
    public class PiiRepository<T>: IPiiRepository<T>
    {
        public async Task<IUser<T>> FindAsync(string nameIdentifier)
        {
            return await Task.FromResult(new User<T>());
        }

        public async Task<IUser<T>> FindAsync(T piiUserId)
        {
            return await Task.FromResult(new User<T>());
        }
    }
}