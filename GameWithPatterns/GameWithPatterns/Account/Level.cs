﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account
{
    abstract class Level
    {
        protected Player Player;
        protected float BonusMovement;
        protected int ExpToNextLevel;

        protected abstract void SetMovement();
    }
}
