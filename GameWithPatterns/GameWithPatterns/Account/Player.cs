using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameWithPatterns.Account;
using GameWithPatterns.Account.PlayerLevels;

namespace GameWithPatterns.Account
{
    public class Player
    {
        private Level Level { get; set; }
        private string Name { get; set; }

        private static Player Instance;
        private static object padlock = new object();

        private Player(string name)
        {
            Name = name;
            Level = new BasicLevel();
        }

        public static Player GetInstance(string name = "Player")
        {
            if (Instance == null)
            {
                lock (padlock)
                {
                    if (Instance == null)
                    {
                        Instance = new Player(name);
                    }
                }
            }
            return Instance;
        }
    }
}
