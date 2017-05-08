using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    class InjuredState : IHealth
    {
        private Player _player;

        public InjuredState(Player player)
        {
            _player = player;
            _player.Health = 70;
            _player.Movement = 70; //...
        }

        public void Heal()
        {
            _player.HealthState = new HealthyState(_player);
        }

        public void Move()
        {
            _player.Movement = 70;
        }

        public void ApplyDamage()
        {
            _player.AttackDamage = 70;
        }

        public void Attack()
        {
            _player.Accuracy = 70;
        }
    }
}
