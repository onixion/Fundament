using System;
using System.Diagnostics;

namespace GroundWork
{
    /// <summary>
    /// Throttle.
    /// </summary>
    public class Throttle
    {
        readonly TimeSpan throttleTimeSpan;
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
            if (stopwatch.Elapsed > throttleTimeSpan)
            {
                stopwatch.Restart();
                return true;
            }

            return false;
        }
    }
}
