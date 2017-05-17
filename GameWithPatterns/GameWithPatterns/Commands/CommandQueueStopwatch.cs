using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Commands
{
    public static class CommandQueueStopwatch
    {
        private static readonly Stopwatch _watch = Stopwatch.StartNew();
        public static long GetTimeMillis()
        {
            return _watch.ElapsedMilliseconds;
        }

    }
}
