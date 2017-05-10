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
        public int HealthThreshold { get; set; }

        public HealthyState(Player player)
        {
            _player = player;
            HealthThreshold = 70;
        }

        public void Heal()
        {
            // nothing happen if take medic, so?
        }

        public void Move()
        {
            _player.Movement = 100;
        }

        public void ApplyDamage(int damage)
        {
            _player.Health -= damage;
            if (_player.Health <= HealthThreshold)
            {
                _player.HealthState = new InjuredState(_player);
            }
        }

        public void Attack()
        {
            _player.Accuracy = 100;
        }
    }
}
