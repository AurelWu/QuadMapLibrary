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
        public static void TestMethod()
        {
            NativeList<int2> testList = new NativeList<int2>(Allocator.Temp);
            testList.Add(new int2(3, 5));
            GetTiles.AdjacentToTile(new int2(3, 5), testList);
            Debug.Log(testList[0]);
            Debug.Log(testList[1]);
            Debug.Log(testList[2]);
            Debug.Log(testList[3]);
            Debug.Log(testList[4]);
            testList.Dispose();
        }
    }
}
