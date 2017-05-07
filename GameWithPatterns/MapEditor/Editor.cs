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

namespace MapEditor
{
    public partial class Editor : Form
    {
        private Form settingsForm;
        private static volatile Editor instance;
        private static readonly object padlock = new object();
        public Color settingsColor = Color.White;
        public ElementType settingsType;
        public MapManager mapManager;

        private Editor()
        {
            InitializeComponent();
            settingsForm = new Settings();
            settingsForm.Show();

            mapManager = MapManager.getInstance();
        }

        public static Editor getInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Editor();
                    }
                }
            }
            return instance;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            using (Graphics g = this.Map.CreateGraphics())
            {
                Pen pen = new Pen(settingsColor, 2);

                var point = Map.PointToClient(Cursor.Position);
                var elementLocation = SearchPlaceForElement(point);

                g.DrawRectangles(pen, new[] { new Rectangle(elementLocation.X, elementLocation.Y, 32, 32) });
                g.FillRectangles(new SolidBrush(settingsColor), new[] { new Rectangle(elementLocation.X, elementLocation.Y, 32, 32) });
                pen.Dispose();

                mapManager.AddItem(new MapElement
                {
                    Location = new Point(elementLocation.X, elementLocation.Y),
                    Name = "TestName",
                    Type = settingsType,
                });
            }
            //var point = panel1.PointToClient(Cursor.Position);
            //MessageBox.Show(point.ToString());
        }

        private Point SearchPlaceForElement(Point cursor)
        {
            for (int i = 0; i < Map.Width; i += 32)
            {
                for (int j = 0; j < Map.Height; j += 32)
                {
                    if ((cursor.X >= i && cursor.X < i + 32) && (cursor.Y >= j && cursor.Y < j + 32))
                    {
                        return new Point(i, j);
                    }
                }
            }

            return new Point();
        }
    }
}
