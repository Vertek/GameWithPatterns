using System.Drawing;
using GameWithPatterns.Account.Health;

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

        public Point Position;

        private static Player _instance;
        private static readonly object Padlock = new object();

        public float Movement { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public int Accuracy { get; set; }

        private Player()
        {
            _healthState = new HealthyState(this);
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
