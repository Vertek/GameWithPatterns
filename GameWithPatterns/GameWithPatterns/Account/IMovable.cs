using GameWithPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithPatterns.Account
{
    public interface IMovable
    {
        Vector Position { get; set; }
        Point Direction { get; set; }
        long LastMoveTimestamp { get; set; }
        float Movement { get; set; }
    }
}
