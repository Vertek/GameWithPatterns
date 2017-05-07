using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilsLibrary.Map;

namespace GameWithPatterns
{
    public partial class Game : Form
    {
        private static volatile Game instance;
        private static readonly object padlock = new object();
        private List<MapElement> mapElements;

        private Game()
        {
            InitializeComponent();

            var parser = new Utils.MapParser();
            mapElements = parser.ParseJsonToMap();
            GameWindow.Invalidate();
        }

        public static Game getInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Game();
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
            //ParseMapElement(new MapElement { Location = new Point(32,32), Type = ElementType.Sand, Name = "gowno"});
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
    }
}
