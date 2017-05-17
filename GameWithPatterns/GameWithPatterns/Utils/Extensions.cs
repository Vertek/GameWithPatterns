using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWithPatterns.Utils
{
    public static class Extensions
    {
        public static void AddItem(this Dictionary<Keys, bool> keys, Keys key, bool isPressed)
        {

        }

        public static int ToInt32<T>(this T number, int def = 0) where T : struct 
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch(Exception ex)
            {
                return def;
            }
        }
    }
}
