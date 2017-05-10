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

        private GameForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, true);
            KeyPreview = true;
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
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                _player.Position.Y += 10;
            }

            if (e.KeyCode == Keys.D)
            {
                _player.Position.X += 10;
            }

            if (e.KeyCode == Keys.A)
            {
                _player.Position.X -= 10;
            }

            if (e.KeyCode == Keys.W)
            {
                _player.Position.Y -= 10;
            }
        }
    }
}
