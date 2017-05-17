using GameWithPatterns.Account;
using GameWithPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWithPatterns.Commands
{
    public class MoveCommand : BaseCommand
    {
        private Point _direction;
        private IMovable _player;

        public MoveCommand(Point direction, IMovable player)
        {
            _direction = direction;
            _player = player;
        }

        public override void Execute()
        {
            long previous = _player.LastMoveTimestamp;
            long cmdTimestamp = GetTimestamp();
            long dt = (cmdTimestamp - previous);
            if (dt < 0)
                dt = 0;

           _player.Position = new Vector(
               _player.Position.X + _player.Direction.X * dt / 1000f * _player.Movement, 
               _player.Position.Y + _player.Direction.Y * dt / 1000f * _player.Movement);
            _player.LastMoveTimestamp = cmdTimestamp;
            _player.Direction= _direction;
        }
    }
}
