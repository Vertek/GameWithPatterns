using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UtilsLibrary.Map;

namespace MapEditor.Utils
{
    public static class Extensions
    {
        public static bool AAA(string text)
        {
            return true;
        }

        public static void AddMapElement(this List<MapElement> mapElements, MapElement element)
        {     
            var obj = mapElements.FirstOrDefault(x => x.Location == element.Location);
            mapElements.Remove(obj);
            mapElements.Add(element);
        }
    }
}
