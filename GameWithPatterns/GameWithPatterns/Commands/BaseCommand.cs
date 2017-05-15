using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private readonly long _timestamp;

        public BaseCommand()
        {
            _timestamp = Stopwatch.GetTimestamp();
        }

        public abstract void Execute();

        public long GetTimestamp()
        {
            return _timestamp;
        }
    }
}
