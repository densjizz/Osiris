using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Map
{
    public class Tile
    {
        public TileProperty properties { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Tile(int x, int y) {
            X = x;
            Y = y;
            properties = new TileProperty();
        }
    }
}
