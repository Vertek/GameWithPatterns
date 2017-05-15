using GameWithPatterns.Account;
using GameWithPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Commands
{
    public class MoveCommand : BaseCommand
    {
        private Vector _direction;
        private Player _player;

        public MoveCommand(Vector direction, Player player)
        {
            _direction = direction;
            _player = player;
        }

        public override void Execute()
        {
            var previous = GetTimestamp();
            var currentTime = Stopwatch.GetTimestamp();
            var differentTime = (currentTime - previous) / 60;
            _player.Position = new System.Drawing.Point(differentTime * _player.Movement)
        }
    }
}
