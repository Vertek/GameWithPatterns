using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Monsters
{
    public interface IMonster
    {
        int Health { get; set; }
        int Movement { get; set; }
        int Damage { get; set; }

        void Attack();

    }
}
