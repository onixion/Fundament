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
        public static async Task CatchIgnoreAsync(Func<Task> action)
        {
            Argument.NotNull(nameof(action), action);

            try
            {
                await action();
            }
            catch
            {
                // ignore
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
        /// Catch exception from action asynchronously.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync(Func<Task> action, Action<Exception> exception)
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                await action();
            }
            catch (Exception e)
            {
                exception(e);
            }
        }

        /// <summary>
        /// Catch exception from action asynchronously.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync(Func<Task> action, Func<Exception, Task> exception)
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                await action();
            }
            catch (Exception e)
            {
                await exception(e);
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

        /// <summary>
        /// Catch specific exception asynchronously.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync<TException>(Func<Task> action, Action<TException> exception) where TException : Exception
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                await action();
            }
            catch (TException e)
            {
                exception(e);
            }
        }

        /// <summary>
        /// Catch specific exception asynchronously.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync<TException>(Func<Task> action, Func<TException, Task> exception) where TException : Exception
        {
            Argument.NotNull(nameof(action), action);
            Argument.NotNull(nameof(exception), exception);

            try
            {
                await action();
            }
            catch (TException e)
            {
                await exception(e);
            }
        }
    }
}
