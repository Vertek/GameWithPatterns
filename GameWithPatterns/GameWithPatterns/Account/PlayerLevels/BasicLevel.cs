using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account.PlayerLevels
{
    class BasicLevel : Level
    {
        public BasicLevel(Level level)
        {
            this.BonusMovement = 10;
            this.ExpToNextLevel = 40;
        }

        protected override void SetMovement()
        {
            
        }
    }
}
