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
            var gameEngine = new GameEngine(_player, GameWindow);
            gameEngine.Status = GameStatus.Started;
            gameEngine.GameWorker.RunWorkerAsync();
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
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyManager.KeyReaction(e.KeyCode, true);
            if (e.KeyCode == Keys.S)
            {
                _player.Position.Y += 10;
                label2.Text = "DOWN: true";
            }

            if (e.KeyCode == Keys.D)
            {
                _player.Position.X += 10;
                label3.Text = "RIGHT: true";
            }

            if (e.KeyCode == Keys.A)
            {
                _player.Position.X -= 10;
                label4.Text = "LEFT: true";
            }

            if (e.KeyCode == Keys.W)
            {
                _player.Position.Y -= 10;
                label1.Text = "UP: true";
            }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keyManager.KeyReaction(e.KeyCode, false);
            if (e.KeyCode == Keys.S)
            {
                label2.Text = "DOWN: false";
            }

            if (e.KeyCode == Keys.D)
            {
                label3.Text = "RIGHT: false";
            }

            if (e.KeyCode == Keys.A)
            {
                label4.Text = "LEFT: false";
            }

            if (e.KeyCode == Keys.W)
            {
                label1.Text = "UP: false";
            }
        }
    }
}
