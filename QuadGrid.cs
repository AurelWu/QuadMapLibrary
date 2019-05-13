using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;

namespace Wunderwunsch.QuadMapLibrary
{ 
    /// <summary>
    /// This library assumes for all input values on methods handling finite sized maps that the input is a valid coordinate of that map!
    /// </summary>
    public static partial class QuadGrid
    {
        public static bool IsVerticalEdge(Vector2Int inputEdge)
        {
            if (inputEdge.x % 2 != 0) return true; //x is uneven meaning that the edge is between to tiles on the x-axis with same y-coordinate resulting in a vertical edge
            else return false;
        }
    }
}
