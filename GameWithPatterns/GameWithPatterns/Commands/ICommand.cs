using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Commands
{
    public interface ICommand
    {
        long GetTimestamp();
        void Execute();
    }
}
