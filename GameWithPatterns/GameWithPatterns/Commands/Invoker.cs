using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Commands
{
    public static class Invoker
    {
        private static readonly ConcurrentQueue<ICommand> queueCommands = new ConcurrentQueue<ICommand>();

        public static void InvokeCommands()
        {
            foreach(ICommand command in queueCommands)
            {
                ICommand cmd;
                bool isSuccess = queueCommands.TryDequeue(out cmd);
                if(isSuccess)
                {
                    cmd.Execute();
                }
            }
        }

        public static void AddCommand(ICommand command)
        {
            queueCommands.Enqueue(command);
        }
    }
}
