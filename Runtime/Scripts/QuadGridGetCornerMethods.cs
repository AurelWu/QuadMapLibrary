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
        public static class GetCorners
        {
            public static void AdjacentToTile(int2 tilePosition, NativeList<int2> result)
            {
                result.Clear();
                result.Add(new int2( (tilePosition * 4) + new int2(+2, +2)));
                result.Add(new int2( (tilePosition * 4) + new int2(+2, -2)));
                result.Add(new int2( (tilePosition * 4) + new int2(-2, -2)));
                result.Add(new int2( (tilePosition * 4) + new int2(-2, +2)));
            }

            public static List<int2> AdjacentToTile(int2 tilePosition)
            {
                List<int2> result = new List<int2>();
                result.Add(new int2( (tilePosition * 4) + new int2(+2, +2)));
                result.Add(new int2( (tilePosition * 4) + new int2(+2, -2)));
                result.Add(new int2( (tilePosition * 4) + new int2(-2, -2)));
                result.Add(new int2( (tilePosition * 4) + new int2(-2, +2)));
                return result;
            }

            public static List<Vector2Int> AdjacentToTile(Vector2Int tilePosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                result.Add(new Vector2Int((tilePosition.x * 4 + 2), (tilePosition.y *4) + 2));
                result.Add(new Vector2Int((tilePosition.x * 4 + 2), (tilePosition.y *4) - 2));
                result.Add(new Vector2Int((tilePosition.x * 4 - 2), (tilePosition.y *4) - 2));
                result.Add(new Vector2Int((tilePosition.x * 4 - 2), (tilePosition.y *4) + 2));
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
