using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameWithPatterns.Account;
using GameWithPatterns.Engine;
using UtilsLibrary.Map;
using GameWithPatterns.Keyboard;
using GameWithPatterns.Monsters;

namespace GameWithPatterns
{
    public partial class GameForm : Form
    {
        private static volatile GameForm instance;
        private static readonly object padlock = new object();
        private List<MapElement> mapElements;
        private BackgroundWorker worker;
        private bool gameStatus = false;
        private Player _player;
        private KeyManager _keyManager;
        private GameEngine _gameEngine;

        private GameForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable | ControlStyles.OptimizedDoubleBuffer, true);
            KeyPreview = true;
            _keyManager = KeyManager.GetInstance();
            worker = new BackgroundWorker();
            worker.DoWork += WorkerOnDoWork;
            var parser = new Utils.MapParser();
            mapElements = parser.ParseJsonToMap();
            GameWindow.Invalidate();
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            gameStatus = true;
            while (gameStatus)
            {
                
            }
        }

        public static GameForm getInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameForm();
                    }
                }
            }
            return instance;
        }

        //public Form1()
        //{
        //    InitializeComponent();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            _player = Player.GetInstance();
            _gameEngine = new GameEngine(_player, GameWindow);
            _gameEngine.Status = GameStatus.Started;
            _gameEngine.GameWorker.RunWorkerAsync();
        }

        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            foreach (var map in mapElements)
            {
                Pen pen = new Pen(map.getColor(), 2);

                g.DrawRectangles(pen, new[] {new Rectangle(map.Location.X, map.Location.Y, 32, 32)});
                g.FillRectangles(new SolidBrush(map.getColor()), new[] { new Rectangle(map.Location.X, map.Location.Y, 32, 32) });
                pen.Dispose();
            }
            if (_player != null)
                g.FillEllipse(Brushes.Black, _player.Position.X, _player.Position.Y, 16, 16);

            if(_gameEngine != null)
            {
                var monsters = _gameEngine.GetMonsters();

                foreach (var item in monsters)
                {
                    g.FillEllipse(Brushes.Silver, ((StandardZombie)item).position.X, ((StandardZombie)item).position.Y, 16, 16);
                }
            }
        }

        public int count = 0;

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyManager.KeyReaction(e.KeyCode, true);
            _keyManager.CheckKeysPressed(_player);

            label2.Text = "X: " + _player.Position.X + " Y: " + _player.Position.Y + " C: " + count++;
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keyManager.KeyReaction(e.KeyCode, false);
            _keyManager.CheckKeysPressed(_player);
            label2.Text = "X: " + _player.Position.X + " Y: " + _player.Position.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            var x = r.Next(50, 250);
            var y = r.Next(50, 250);
            var monster = new StandardZombie();
            monster.position = new Point(x, y);
            _gameEngine.AddMonster(monster);
        }
    }
}
