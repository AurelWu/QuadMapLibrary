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
    /// <summary>
    /// Tests if different overloads of the same method provide the same results when they should
    /// </summary>
    public class ConsistencyTests
    {
        [Test]
        public void GetTilesAdjacentToTileInfiniteGrid([Values(-3122,-5,-1,0, 1, 6, 31941)] int x, [Values(-115422, -5, -1, 0, 1, 6, 27441)] int y)
        {
            NativeList<int2> result3 = new NativeList<int2>(16, Allocator.Temp);
            int2 pos = new int2(x, y);
            Vector2Int posVector2Int = new Vector2Int(x, y);
            var result1 = QuadGrid.GetTiles.AdjacentToTile(pos);
            var result2 = QuadGrid.GetTiles.AdjacentToTile(posVector2Int);
            QuadGrid.GetTiles.AdjacentToTile(pos, result3);

            Assert.AreEqual(result1.Count, result2.Count);
            Assert.AreEqual(result1.Count, result3.Length);

            for(int i = 0; i < result1.Count; i++)
            {
                Assert.AreEqual(result1[i].x, result2[i].x);
                Assert.AreEqual(result1[i].y, result3[i].y);
            }

            result3.Dispose();
        }

        [Test]
        public void GetTilesAdjacentToTileFiniteMap([Values(-3122, -5, -1, 0, 1, 6, 31941,30000)] int x, [Values(-115422, -5, -1, 0, 1, 6, 27441,50000)] int y, [Values(5,35,30000)] int mapSizeX, [Values(4, 25, 50000)] int mapSizeY)
        {
            int2 mapSize = new int2(mapSizeX, mapSizeY);
            Vector2Int mapSizeVector2Int = new Vector2Int(mapSizeX, mapSizeY);
            NativeList<int2> result3 = new NativeList<int2>(16, Allocator.Temp);
            int2 pos = new int2(x, y);
            Vector2Int posVector2Int = new Vector2Int(x, y);

            if (x < 0 || y < 0 || x >= mapSizeX || y >= mapSizeY)
            {
                Assert.Throws<System.ArgumentOutOfRangeException>(InvalidArgumentValues);
                Assert.Throws<System.ArgumentOutOfRangeException>(InvalidArgumentValuesInt2);
                Assert.Throws<System.ArgumentOutOfRangeException>(InvalidArgumentValuesInt2NativeList);

                void InvalidArgumentValues()
                {
                    var result = QuadGrid.GetTiles.AdjacentToTile(posVector2Int, mapSizeVector2Int);
                }

                void InvalidArgumentValuesInt2()
                {
                    var result = QuadGrid.GetTiles.AdjacentToTile(pos, mapSize);
                }

                void InvalidArgumentValuesInt2NativeList()
                {
                    QuadGrid.GetTiles.AdjacentToTile(pos, mapSize,result3);
                }
            }

            else
            {
                var result1 = QuadGrid.GetTiles.AdjacentToTile(pos, mapSize);
                var result2 = QuadGrid.GetTiles.AdjacentToTile(posVector2Int, mapSizeVector2Int);
                QuadGrid.GetTiles.AdjacentToTile(pos, mapSize, result3);

                Assert.AreEqual(result1.Count, result2.Count);
                Assert.AreEqual(result1.Count, result3.Length);

                for (int i = 0; i < result1.Count; i++)
                {
                    Assert.AreEqual(result1[i].x, result2[i].x);
                    Assert.AreEqual(result1[i].y, result3[i].y);
                }
            }

            result3.Dispose();
        }

        [Test]
        public void GetTilesAdjacentToEdgeInfiniteGrid([Values(-3122, -5, -1, 0, 1, 6, 31941)] int x, [Values(-115422, -5, -1, 0, 1, 6, 27441)] int y)
        {
            NativeList<int2> result3 = new NativeList<int2>(16, Allocator.Temp);
            int2 pos = new int2(x, y);
            Vector2Int posVector2Int = new Vector2Int(x, y);
            var result1 = QuadGrid.GetTiles.AdjacentToEdge(pos);
            var result2 = QuadGrid.GetTiles.AdjacentToEdge(posVector2Int);
            QuadGrid.GetTiles.AdjacentToEdge(pos, result3);

            Assert.AreEqual(result1.Count, result2.Count);
            Assert.AreEqual(result1.Count, result3.Length);

            for (int i = 0; i < result1.Count; i++)
            {
                Assert.AreEqual(result1[i].x, result2[i].x);
                Assert.AreEqual(result1[i].y, result3[i].y);
            }

            result3.Dispose();
        }

        [Test]
        public void GetTilesAdjacentToCornerInfiniteGrid([Values(-3122, -5, -1, 0, 1, 6, 31941)] int x, [Values(-115422, -5, -1, 0, 1, 6, 27441)] int y)
        {
            NativeList<int2> result3 = new NativeList<int2>(16, Allocator.Temp);
            int2 pos = new int2(x, y);
            Vector2Int posVector2Int = new Vector2Int(x, y);
            var result1 = QuadGrid.GetTiles.AdjacentToCorner(pos);
            var result2 = QuadGrid.GetTiles.AdjacentToCorner(posVector2Int);
            QuadGrid.GetTiles.AdjacentToCorner(pos, result3);

            Assert.AreEqual(result1.Count, result2.Count);
            Assert.AreEqual(result1.Count, result3.Length);

            for (int i = 0; i < result1.Count; i++)
            {
                Assert.AreEqual(result1[i].x, result2[i].x);
                Assert.AreEqual(result1[i].y, result3[i].y);
            }

            result3.Dispose();
        }
    }
}
