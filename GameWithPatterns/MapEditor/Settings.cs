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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadColors();
            LoadTypes();

        }

        private void LoadTypes()
        {
            foreach(var abc in Enum.GetValues(typeof(ElementType)))
            {
                comboBox1.Items.Add(abc);
            }
        }

        private void LoadColors()
        {
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                Colors.Items.Add(Color.FromKnownColor(color).Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(Colors.Text);

            using (var g = colorHint.CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, Width, Height));
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            var editor = Editor.getInstance();
            editor.settingsColor = Color.FromName(Colors.Text);
            editor.settingsType = (ElementType)Enum.Parse(typeof(ElementType), comboBox1.Text);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var manager = MapManager.getInstance();
            manager.GetMap();
        }
    }
}
