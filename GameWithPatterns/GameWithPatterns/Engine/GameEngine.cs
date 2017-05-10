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

        public GameEngine(Player player, Control gameWindow)
        {
            _player = player;
            _gameWindow = gameWindow;
            GameWorker = new BackgroundWorker();
            GameWorker.DoWork += Game;
        }

        public void Game(object sender, DoWorkEventArgs e)
        {
            while (Status == GameStatus.Started)
            {
                //RenderMap();
                InitializePlayer();
                InitializeMonsters();
                Thread.Sleep(100);
            }
        }

        public void RenderMap()
        {
            _gameWindow.Invalidate();
        }

        public void InitializePlayer()
        {
            var g = _gameWindow.CreateGraphics();
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
