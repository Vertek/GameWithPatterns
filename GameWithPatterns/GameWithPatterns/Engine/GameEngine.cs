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

        public GameEngine(Player player, Control gameWindow)
        {
            _player = player;
            _gameWindow = gameWindow;
            GameWorker = new BackgroundWorker();
            GameWorker.DoWork += Game;
            g = gameWindow.CreateGraphics();
        }

        public void Game(object sender, DoWorkEventArgs e)
        {
            while (Status == GameStatus.Started)
            {
                RenderMap();
                //InitializePlayer();
                InitializeMonsters();
                Thread.Sleep(100);
            }
        }

        public void RenderMap()
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, _gameWindow, new object[] { true });
            _gameWindow.Invalidate();
        }

        public void InitializePlayer()
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, _gameWindow, new object[] { true });
            g.FillEllipse(new SolidBrush(Color.Black), _player.Position.X, _player.Position.Y, 16, 16);
        }

        public void InitializeMonsters()
        {
            
        }

        public void InitializeItems()
        {
            
        }
    }
}
