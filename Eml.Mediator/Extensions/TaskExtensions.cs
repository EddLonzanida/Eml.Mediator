using System.Threading.Tasks;

namespace Eml.Mediator.Extensions
{
    internal static class TaskExtensions
    {
        public static Task ConfigureAwaitFalse(this Task task)
        {
            task.ConfigureAwait(false);
            return task;
        }

        public static Task<T> ConfigureAwaitFalse<T>(this Task<T> task)
        {
            task.ConfigureAwait(false);
            return task;
        }
    }
}