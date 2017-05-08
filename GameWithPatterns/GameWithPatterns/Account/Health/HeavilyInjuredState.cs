using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class HeavilyInjuredState : IHealth
    {
        private Player _player;

        public HeavilyInjuredState(Player player)
        {
            _player = player;
            _player.Health = 40;
        }

        public void Heal()
        {
            _player.HealthState = new InjuredState(_player);
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
