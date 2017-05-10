using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.Health
{
    public interface IHealth
    {
        int HealthThreshold { get; set; }
        void Heal();
        void Move();
        void ApplyDamage(int damage);
        void Attack();
    }
}
