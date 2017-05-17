using GameWithPatterns.Account;
using GameWithPatterns.Commands;
using GameWithPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Monsters
{
    public abstract class BaseMonster : IMonster, IMovable
    {
        public int Damage;
        public int Health;
        public float Movement { get; set; }

        private long _lastMoveTimestamp = -1;
        public long LastMoveTimestamp
        {
            get
            {
                if (_lastMoveTimestamp < 0)
                {
                    _lastMoveTimestamp = CommandQueueStopwatch.GetTimeMillis();
                }
                return _lastMoveTimestamp;
            }
            set
            {
                _lastMoveTimestamp = value;
            }
        }

        private Vector _position;
        public Vector Position
        {
            get
            {
                if (_position == null)
                {
                    _position = new Vector(0, 0);
                }
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        private Point _direction;
        public Point Direction
        {
            get
            {
                if (_direction == null)
                {
                    _direction = new Point(0, 0);
                }
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public BaseMonster()
        {

        }

        public abstract int Attack();

        public abstract float Move();
    }
}
