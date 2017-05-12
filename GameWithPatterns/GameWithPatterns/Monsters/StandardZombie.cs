using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Monsters
{
    public class StandardZombie : IMonster
    {
        public int Damage
        {
            get
            {
                return Damage;
            }

            set
            {
                Damage = value;
            }
        }

        public int Health
        {
            get
            {
                return Health;
            }

            set
            {
                Health = value;
            }
        }

        public int Movement
        {
            get
            {
                return Movement;
            }

            set
            {
                Movement = value;
            }
        }

        public Point position;

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
