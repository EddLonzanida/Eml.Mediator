using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.Classes
{
    public interface IEmlRepository<T>
    {
        Task<IUser<T>> FindAsync(string nameIdentifier);
        Task<IUser<T>> FindAsync(T emlUserId);
    }
}