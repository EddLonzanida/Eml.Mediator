using System.Threading.Tasks;

namespace Eml.Mediator.Extensions
{
    internal static class TaskExtensions
    {
        /// <summary>
        /// Use this to prevent UI from freezing.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static Task ConfigureAwaitFalse(this Task task)
        {
            task.ConfigureAwait(false);
            return task;
        }

        /// <summary>
        /// Use this to prevent UI from freezing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static Task<T> ConfigureAwaitFalse<T>(this Task<T> task)
        {
            task.ConfigureAwait(false);
            return task;
        }
    }
}