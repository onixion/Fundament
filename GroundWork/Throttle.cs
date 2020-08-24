using System;
using System.Diagnostics;

namespace Groundwork
{
    /// <summary>
    /// Throttle.
    /// </summary>
    public class Throttle
    {
        /// <summary>
        /// Throttle time span.
        /// </summary>
        readonly TimeSpan throttleTimeSpan;

        /// <summary>
        /// Stop watch.
        /// </summary>
        readonly Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="throttleTimeSpan">Throttle time span.</param>
        public Throttle(TimeSpan throttleTimeSpan)
        {
            this.throttleTimeSpan = throttleTimeSpan;
            stopwatch.Start();
        }

        /// <summary>
        /// Check and update throttling.
        /// </summary>
        /// <returns>If true, then it is throttling, false otherwise.</returns>
        public bool IsThrottling()
        {
            lock(stopwatch)
            {
                if (stopwatch.Elapsed > throttleTimeSpan)
                {
                    stopwatch.Restart();
                    return true;
                }

                return false;
            }
        }
    }
}
