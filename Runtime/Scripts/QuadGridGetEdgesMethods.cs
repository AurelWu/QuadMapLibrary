using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;

namespace Wunderwunsch.QuadMapLibrary
{ 
    public static partial class QuadGrid
    {
        public static class GetEdges
        {
            public static void AdjacentToTile(int2 tilePosition, NativeList<int2> result)
            {
                result.Clear();
                result.Add(tilePosition*2 + new int2(1, 0));
                result.Add(tilePosition*2 + new int2(-1, 0));
                result.Add(tilePosition*2 + new int2(0, 1));
                result.Add(tilePosition*2 + new int2(0, -1));
            }

            public static List<int2> AdjacentToTile(int2 tilePosition)
            {
                List<int2> result = new List<int2>();
                result.Add(tilePosition * 2 + new int2(1, 0));
                result.Add(tilePosition * 2 + new int2(-1, 0));
                result.Add(tilePosition * 2 + new int2(0, 1));
                result.Add(tilePosition * 2 + new int2(0, -1));
                return result;
            }

            public static List<Vector2Int> AdjacentToTile(Vector2Int tilePosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                result.Add(tilePosition * 2 + new Vector2Int(1, 0));
                result.Add(tilePosition * 2 + new Vector2Int(-1, 0));
                result.Add(tilePosition * 2 + new Vector2Int(0, 1));
                result.Add(tilePosition * 2 + new Vector2Int(0, -1));
                return result;
            }

            public static void AdjacentToEdge()
            {
                throw new System.NotImplementedException();
            }

            public static void AdjacentToCorner()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}

//com.wunderwunsch.quadmaplibrary
