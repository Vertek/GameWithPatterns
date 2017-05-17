using GameWithPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Monsters
{
    public class StandardZombie : BaseMonster
    {
        public StandardZombie()
        {
            Health = 100;
            Damage = 10;
            Movement = 5;
        }

        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public override float Move()
        {
            throw new NotImplementedException();
        }
    }
}
