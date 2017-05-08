using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class HealthyState : IHealth
    {
        private Player _player;

        public HealthyState(Player player)
        {
            _player = player;
        }

        public void Heal()
        {
            // nothing happen if take medic
        }

        public void Move()
        {
            _player.Movement = 100;
        }

        public void ApplyDamage()
        {
            _player.AttackDamage = 100;
        }

        public void Attack()
        {
            _player.Accuracy = 100;
        }
    }
}
