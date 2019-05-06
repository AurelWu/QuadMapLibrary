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
                result.Add(tilePosition*2 + new int2(1, 0));
                result.Add(tilePosition*2 + new int2(-1, 0));
                result.Add(tilePosition*2 + new int2(0, 1));
                result.Add(tilePosition*2 + new int2(0, -1));
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
