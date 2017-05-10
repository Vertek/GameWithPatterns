using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class InjuredState : IHealth
    {
        private readonly Player _player;
        public int HealthThreshold { get; set; }

        public InjuredState(Player player)
        {
            _player = player;
        }

        public void Heal()
        {
            _player.HealthState = new HealthyState(_player);
        }

        public void Move()
        {
            _player.Movement = 70; //???
        }

        public void ApplyDamage(int damage)
        {
            _player.Health -= damage;
            if (_player.Health <= HealthThreshold)
            {
                _player.HealthState = new HeavilyInjuredState(_player);
            }
        }

        public void Attack()
        {
            _player.Accuracy = 70;
        }
    }
}
