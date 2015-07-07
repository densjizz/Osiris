using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Map
{
    public class Map
    {
        public Tile[,] Tiles;


        public Map(int width, int height) {
            Tiles = new Tile[width, height];
            GenerateEmpty();
        }

        private void GenerateEmpty()
        {
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    Tiles[i, j] = new Tile(i, j);
                }
            }
        }
    }
}
