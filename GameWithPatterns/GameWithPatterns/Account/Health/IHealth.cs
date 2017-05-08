using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    public interface IHealth
    {
        void Heal();
        void Move();
        void ApplyDamage();
        void Attack();
    }
}
