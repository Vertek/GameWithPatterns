using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using UtilsLibrary.Map;

namespace GameWithPatterns.Utils
{
    public class MapParser
    {
        public List<MapElement> ParseJsonToMap()
        {
            var path = @"D:\Repos\GameWithPatterns\GameWithPatterns\GameWithPatterns\Map.json";
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<MapElement>>(json);
        }
    }
}
