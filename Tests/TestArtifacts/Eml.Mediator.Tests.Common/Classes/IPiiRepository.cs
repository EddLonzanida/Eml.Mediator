using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.Classes
{
    public interface IPiiRepository<T> : IDiDiscoverableTransient
    {
        Task<IUser<T>> FindAsync(string nameIdentifier);
        Task<IUser<T>> FindAsync(T piiUserId);
    }
}