using System;
using System.Drawing;
using GameWithPatterns.Account.Health;
using GameWithPatterns.Utils;
using GameWithPatterns.Commands;

namespace GameWithPatterns.Account
{
    public class Player
    {
        private IHealth _healthState;
        public IHealth HealthState
        {
            get { return _healthState; }
            set { _healthState = value; }
        }
        public Point Direction = new Point(0, 0);
        public Vector Position = new Vector(0, 0);

        private static Player _instance;
        private static readonly object Padlock = new object();

        public float Movement { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
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
            }set
            {
                _lastMoveTimestamp = value;
            }
        }

        public int Accuracy { get; set; }

        private Player()
        {
            _healthState = new HealthyState(this);
            Health = 100;
            Movement = 100;
            AttackDamage = 10;
            Accuracy = 10;
        }

        public static Player GetInstance()
        {
            if (_instance == null)
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Player();
                    }
                }
            }
            return _instance;
        }
    }
}
