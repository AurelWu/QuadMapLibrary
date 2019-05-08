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
        public static class GetTiles
        {            
            /// <summary>
            /// returns the 4-way neighbours of the input tile, the passed in NativeList gets cleared before adding the neighbours
            /// </summary>            
            public static void AdjacentToTile(int2 tilePosition, NativeList<int2> result)
            {
                result.Clear(); 
                result.Add(tilePosition + new int2(+0, +1));
                result.Add(tilePosition + new int2(+1, +0));
                result.Add(tilePosition + new int2(+0, -1));
                result.Add(tilePosition + new int2(-1, +0));
            }

            public static void AdjacentToTile(int2 tilePosition,int2 mapSize , NativeList<int2> result)
            {

                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                result.Clear();
                if(tilePosition.y < mapSize.y - 1) result.Add(tilePosition + new int2(+0, +1));
                if(tilePosition.x < mapSize.x - 1) result.Add(tilePosition + new int2(+1, +0));
                if(tilePosition.y > 0) result.Add(tilePosition + new int2(+0, -1));
                if(tilePosition.x > 0) result.Add(tilePosition + new int2(-1, +0));                
            }

            /// <summary>
            /// returns the 4-way neighbours of the input tile
            /// </summary>            
            public static List<int2> AdjacentToTile(int2 tilePosition)
            {
                List<int2> result = new List<int2>();
                result.Add(tilePosition + new int2(+0, +1));
                result.Add(tilePosition + new int2(+1, +0));
                result.Add(tilePosition + new int2(+0, -1));
                result.Add(tilePosition + new int2(-1, +0));
                return result;
            }

            /// <summary>
            /// returns the 4-way neighbours of the input tile
            /// </summary>            
            public static List<int2> AdjacentToTile(int2 tilePosition, int2 mapSize)
            {

                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                List<int2> result = new List<int2>();
                if(tilePosition.y < mapSize.y - 1) result.Add(tilePosition + new int2(+0, +1));
                if(tilePosition.x < mapSize.x - 1) result.Add(tilePosition + new int2(+1, +0));
                if(tilePosition.y > 0) result.Add(tilePosition + new int2(+0, -1));
                if(tilePosition.x > 0) result.Add(tilePosition + new int2(-1, +0));
                return result;
            }

            /// <summary>
            /// returns the 4-way neighbours of the input tile
            /// </summary>            
            public static List<Vector2Int> AdjacentToTile(Vector2Int tilePosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                result.Add(tilePosition + new Vector2Int(+0, +1));
                result.Add(tilePosition + new Vector2Int(+1, +0));
                result.Add(tilePosition + new Vector2Int(+0, -1));
                result.Add(tilePosition + new Vector2Int(-1, +0));
                return result;
            }

            /// <summary>
            /// returns the 4-way neighbours of the input tile
            /// </summary>            
            public static List<Vector2Int> AdjacentToTile(Vector2Int tilePosition, Vector2Int mapSize)
            {
                if(tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                List<Vector2Int> result = new List<Vector2Int>();
                if(tilePosition.y < mapSize.y - 1) result.Add(tilePosition + new Vector2Int(+0, +1));
                if(tilePosition.x < mapSize.x - 1) result.Add(tilePosition + new Vector2Int(+1, +0));
                if(tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(+0, -1));
                if(tilePosition.x > 0) result.Add(tilePosition + new Vector2Int(-1, +0));
                return result;
            }

            public static void AdjacentToEdge(int2 edgePosition, NativeList<int2> result)
            {
                result.Clear();
                if (edgePosition.x % 2 == 0) //x value is unchanged, meaning that we have a horizontal edge
                {
                    result.Add(new int2( edgePosition.x / 2, (edgePosition.y + 1) / 2));
                    result.Add(new int2( edgePosition.x / 2, (edgePosition.y - 1) / 2));
                }
                else //y value is unchanged meaning we have vertical edge
                {
                    result.Add(new int2( (edgePosition.x+1) / 2, edgePosition.y / 2));
                    result.Add(new int2( (edgePosition.x-1) / 2, edgePosition.y / 2));
                }
            }

            public static List<int2> AdjacentToEdge(int2 edgePosition)
            {
                List<int2> result = new List<int2>();

                if (edgePosition.x % 2 == 0) //x value is unchanged, meaning that we have a horizontal edge
                {
                    result.Add(new int2(edgePosition.x / 2, (edgePosition.y + 1) / 2));
                    result.Add(new int2(edgePosition.x / 2, (edgePosition.y - 1) / 2));
                }
                else //y value is unchanged meaning we have vertical edge
                {
                    result.Add(new int2((edgePosition.x + 1) / 2, edgePosition.y / 2));
                    result.Add(new int2((edgePosition.x - 1) / 2, edgePosition.y / 2));
                }

                return result;
            }

            public static List<Vector2Int> AdjacentToEdge(Vector2Int edgePosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();

                if (edgePosition.x % 2 == 0) //x value is unchanged, meaning that we have a horizontal edge
                {
                    result.Add(new Vector2Int(edgePosition.x / 2, (edgePosition.y + 1) / 2));
                    result.Add(new Vector2Int(edgePosition.x / 2, (edgePosition.y - 1) / 2));
                }
                else //y value is unchanged meaning we have vertical edge
                {
                    result.Add(new Vector2Int((edgePosition.x + 1) / 2, edgePosition.y / 2));
                    result.Add(new Vector2Int((edgePosition.x - 1) / 2, edgePosition.y / 2));
                }

                return result;
            }

            public static void AdjacentToCorner(int2 cornerPosition, NativeList<int2> result)
            {
                result.Clear();
                result.Add( (cornerPosition + new int2(+2, +2)) /4 );
                result.Add( (cornerPosition + new int2(+2, -2)) /4 );
                result.Add( (cornerPosition + new int2(-2, -2)) /4);
                result.Add( (cornerPosition + new int2(-2, +2)) /4);
            }

            public static List<int2> AdjacentToCorner(int2 cornerPosition)
            {
                List<int2> result = new List<int2>();
                result.Add((cornerPosition + new int2(+2, +2)) / 4);
                result.Add((cornerPosition + new int2(+2, -2)) / 4);
                result.Add((cornerPosition + new int2(-2, -2)) / 4);
                result.Add((cornerPosition + new int2(-2, +2)) / 4);
                return result;
            }

            public static List<Vector2Int> AdjacentToCorner(Vector2Int cornerPosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                result.Add(new Vector2Int( (cornerPosition.x + 2)/ 4, (cornerPosition.y + 2) / 4));
                result.Add(new Vector2Int((cornerPosition.x + 2) / 4, (cornerPosition.y - 2) / 4));
                result.Add(new Vector2Int((cornerPosition.x - 2) / 4, (cornerPosition.y - 2) / 4));
                result.Add(new Vector2Int((cornerPosition.x - 2) / 4, (cornerPosition.y + 2) / 4));
                return result;
            }
        }
    }
}
