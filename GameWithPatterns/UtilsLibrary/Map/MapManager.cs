using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace UtilsLibrary.Map
{
    public class MapManager
    {
        private List<MapElement> MapElements;
        private static MapManager Instance;
        private static object padlock = new object();

        private MapManager()
        {
            MapElements = new List<MapElement>();
        }

        public static MapManager getInstance()
        {
            if (Instance == null)
            {
                lock (padlock)
                {
                    if (Instance == null)
                    {
                        Instance = new MapManager();
                    }
                }
            }

            return Instance;
        }

        public void AddItem(MapElement element)
        {
            var obj = MapElements.FirstOrDefault(x => x.Location == element.Location);
            MapElements.Remove(obj);
            MapElements.Add(element);
        }

        public bool GetMap()
        {
            File.WriteAllText(string.Format("{0}\\{1}", Environment.CurrentDirectory, "Map.json"), JsonConvert.SerializeObject(MapElements));
            return true;
        }
    }
}
