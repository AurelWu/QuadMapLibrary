using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Wunderwunsch.QuadMapLibrary;
using Unity.Mathematics;
using Unity.Collections;

namespace Tests
{
    public class GetTilesTests
    {
        [Test]
        public void GetTilesAdjacentToTileInfiniteGrid_x0_y0() 
        {
            List<Vector2Int> expectedValues = new List<Vector2Int>();
            expectedValues.Add(new Vector2Int(-1, 0));
            expectedValues.Add(new Vector2Int(+1, 0));
            expectedValues.Add(new Vector2Int(0, +1));
            expectedValues.Add(new Vector2Int(0, -1));
            Vector2Int posVector2Int = new Vector2Int(0, 0);
            var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int);

            Assert.AreEqual(expectedValues.Count, result.Count);
            for(int i = 0; i < result.Count; i++)
            {
                Assert.Contains(result[i], expectedValues);
            }
        }

        [Test]
        public void GetTilesAdjacentToTileInfiniteGrid_x15_y12()
        {
            List<Vector2Int> expectedValues = new List<Vector2Int>();
            expectedValues.Add(new Vector2Int(14, 12));
            expectedValues.Add(new Vector2Int(16, 12));
            expectedValues.Add(new Vector2Int(15, 13));
            expectedValues.Add(new Vector2Int(15, 11));
            Vector2Int posVector2Int = new Vector2Int(15, 12);
            var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int);

            Assert.AreEqual(expectedValues.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Contains(result[i], expectedValues);
            }
        }

        [Test]
        public void GetTilesAtjacentToTileInfiniteGrid_x_n35_y_n4123()
        {
            List<Vector2Int> expectedValues = new List<Vector2Int>();
            expectedValues.Add(new Vector2Int(-36, -4123));
            expectedValues.Add(new Vector2Int(-34, -4123));
            expectedValues.Add(new Vector2Int(-35, -4122));
            expectedValues.Add(new Vector2Int(-35, -4124));
            Vector2Int posVector2Int = new Vector2Int(-35, -4123);
            var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int);

            Assert.AreEqual(expectedValues.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Contains(result[i], expectedValues);
            }
        }


        [Test]
        public void GetTilesAdjacentToTileFiniteMap_x0_y0_mx5_my5()
        {
            List<Vector2Int> expectedValues = new List<Vector2Int>();
            expectedValues.Add(new Vector2Int(+1, 0));
            expectedValues.Add(new Vector2Int(0, +1));

            Vector2Int posVector2Int = new Vector2Int(0, 0);
            var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int,new Vector2Int(5,5));

            Assert.AreEqual(expectedValues.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Contains(result[i], expectedValues);
            }
        }

        [Test]
        public void GetTilesAdjacentToTileFiniteMap_xn1_y0_mx1000_my1000()
        {
            void InvalidArgumentValues()
            {
                Vector2Int posVector2Int = new Vector2Int(-1, 0);
                var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int, new Vector2Int(1000, 1000));
            }
                                   
            Assert.Throws<System.ArgumentOutOfRangeException>(InvalidArgumentValues);
        }

        [Test]
        public void GetTilesFiniteMap_CheckAmountOfCornerAndEdgeTiles([Values(2,3,5,20)] int mx, [Values(2,4,12,50)] int my)
        {
            //there should be 4 corner tiles having 2 neighbours for each map
            //there should be x*2 + y*2 -8 edge tiles with 3 neighbours
            //remainder should be tiles with 4 neighbours
            Vector2Int mapSize = new Vector2Int(mx, my);
            int[] neighbourCounter = new int[5];
            for(int y = 0; y < mapSize.y; y++)
            {
                for(int x = 0; x < mapSize.x; x++)
                {
                    var result = QuadGrid.GetTiles.AdjacentToTile(new Vector2Int(x, y),new Vector2Int(mx,my));
                    neighbourCounter[result.Count]++;
                }
            }
            Assert.AreEqual(neighbourCounter[0], 0);
            Assert.AreEqual(neighbourCounter[1], 0);
            Assert.AreEqual(neighbourCounter[2], 4);
            Assert.AreEqual(neighbourCounter[3], (mx*2)+(my*2)-8);
            Assert.AreEqual(neighbourCounter[4], (mx - 2) * (my - 2));

        }
    }
}
