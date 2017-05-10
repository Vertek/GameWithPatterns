using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class DeadState : IHealth
    {
        public int HealthThreshold { get; set; }
        private Player _player;

        public DeadState(Player player)
        {
            _player = player;
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ApplyDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
