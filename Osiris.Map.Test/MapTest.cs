using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Map.Test
{

    [TestFixture]
    public class MapTest
    {

        [Test]
        public void CreateEmptyMap()
        {
            var map = new Map(0, 0);

            Assert.IsTrue(map.Tiles.Length == 0);
        }


        [Test]
        public void CreateSmallMap()
        {
            var map = new Map(5, 5);

            Assert.IsTrue(map.Tiles.Length == 25);

            Assert.IsTrue(map.Tiles[0,0].X == 0);
            Assert.IsTrue(map.Tiles[0, 0].Y == 0);


            Assert.IsTrue(map.Tiles[2, 2].X == 2);
            Assert.IsTrue(map.Tiles[2, 2].Y == 2);


            Assert.IsTrue(map.Tiles[4, 4].X == 4);
            Assert.IsTrue(map.Tiles[4, 4].Y == 4);
        }
        
    }
}
