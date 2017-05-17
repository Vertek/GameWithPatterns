using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameWithPatterns.Account;
using System.Reflection;
using System.Diagnostics;
using GameWithPatterns.Keyboard;
using GameWithPatterns.Monsters;
using GameWithPatterns.Commands;

namespace GameWithPatterns.Engine
{
    public enum GameStatus
    {
        Stopped,
        Started,
        Paused
    }

    public class GameEngine
    {
        private Player _player;
        public GameStatus Status = GameStatus.Paused;
        public BackgroundWorker GameWorker;
        private Control _gameWindow;
        private Graphics g;
        private KeyManager _keyManager;
        private List<IMonster> _monsters;

        public GameEngine(Player player, Control gameWindow)
        {
            _player = player;
            _gameWindow = gameWindow;
            _keyManager = KeyManager.GetInstance();
            _monsters = new List<IMonster>();
            GameWorker = new BackgroundWorker();
            GameWorker.DoWork += Game;
            g = gameWindow.CreateGraphics();
        }

        public void Game(object sender, DoWorkEventArgs e)
        {
            while (Status == GameStatus.Started)
            {
                RenderMap();
                InitializeMonsters();
                Invoker.InvokeCommands();
                Invoker.AddCommand(new MoveCommand(_player.Direction, _player));
                Thread.Sleep(1);
            }
        }

        public void RenderMap()
        {
            //typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, _gameWindow, new object[] { true });
            _gameWindow.Invalidate();
        }

        public void InitializeMonsters()
        {
            _monsters.Add(new StandardZombie());
        }

        public void InitializeItems()
        {
            
        }
    }
}
