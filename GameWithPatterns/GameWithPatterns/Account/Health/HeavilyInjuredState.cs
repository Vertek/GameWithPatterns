using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class HeavilyInjuredState : IHealth
    {
        private readonly Player _player;
        public int HealthThreshold { get; set; }

        public HeavilyInjuredState(Player player)
        {
            _player = player;
            HealthThreshold = 1;
        }

        public void Heal()
        {
            _player.HealthState = new InjuredState(_player);
        }

        public void Move()
        {
            _player.Movement = 100;
        }

        public void ApplyDamage(int damage)
        {
            _player.Health -= damage;
            if (_player.Health < HealthThreshold)
            {
                _player.HealthState = new DeadState(_player);
            }
        }

        public void Attack()
        {
            _player.Accuracy = 100;
        }
    }
}
