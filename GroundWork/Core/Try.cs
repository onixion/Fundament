using System;
using System.Threading.Tasks;

namespace GroundWork.Core
{
    /// <summary>
    /// Try.
    /// </summary>
    public static class Try
    {
        /// <summary>
        /// Catch ignore exception thrown by the given action.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void CatchIgnore(Action action)
        {
            Argument.NotNull(nameof(action), action);

            try
            {
                action();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore exception thrown by the given async action.
        /// </summary>
        /// <param name="action">Action.</param>
        public static Task CatchIgnoreAsync(Func<Task> action)
        {
            Argument.NotNull(nameof(action), action);

            try
            {
                return action();
            }
            catch
            {
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Catch exception from action and call finally action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="finallyAction">Finally action.</param>
        public static void Finally(Action action, Action finallyAction)
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(finallyAction), finallyAction);

            try
            {
                action();
            }
            finally
            {
                finallyAction();
            }
        }

        /// <summary>
        /// Catch exception from action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static void Catch(Action action, Action<Exception> exception)
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                action();
            }
            catch(Exception e)
            {
                exception(e);
            }
        }

        /// <summary>
        /// Catch specific exception.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static void Catch<TException>(Action action, Action<TException> exception) where TException : Exception
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                action();
            }
            catch (TException e)
            {
                exception(e);
            }
        }
    }
}
