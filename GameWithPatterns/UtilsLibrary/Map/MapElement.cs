using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsLibrary.Map
{
    public class MapElement
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public ElementType Type { get; set; }

        public Color getColor()
        {
            switch (Type)
            {
                case ElementType.Grass:
                    return Color.Green;
                case ElementType.Sand:
                    return Color.Gold;
                case ElementType.Water:
                    return Color.Blue;
                default:
                    return Color.Black;
            }
        }
    }
}
