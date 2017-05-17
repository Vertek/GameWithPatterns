using GameWithPatterns.Account;
using GameWithPatterns.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWithPatterns.Keyboard
{
    public class KeyManager
    {
        private static KeyManager _instance;
        private static readonly object padlock = new object();
        private Dictionary<Keys, bool> keysPressed;

        private KeyManager()
        {
            keysPressed = new Dictionary<Keys, bool>()
            {
                { Keys.W, false },
                { Keys.S, false },
                { Keys.A, false },
                { Keys.D, false }
            };
        }

        public static KeyManager GetInstance()
        {
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new KeyManager();
                    }
                }
            }
            return _instance;
        }

        public void KeyReaction(Keys key, bool keyPressed)
        {
            if (!keysPressed.ContainsKey(key))
            {
                keysPressed.Add(key, keyPressed);
            }
            else
            {
                keysPressed[key] = keyPressed;
            }
        }

        public void CheckKeysPressed(Player player)
        {
            int x = keysPressed[Keys.A] ? -1 : (keysPressed[Keys.D] ? 1 : 0);
            int y = keysPressed[Keys.W] ? -1 : (keysPressed[Keys.S] ? 1 : 0);
            Invoker.AddCommand(new MoveCommand(new Point(x,y), player));
        }
    }
}
