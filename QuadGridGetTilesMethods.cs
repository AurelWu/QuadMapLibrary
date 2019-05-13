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
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
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
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
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
            /// returns the 8-way neighbours of the input tile
            /// </summary>            
            public static List<Vector2Int> AdjacentToTile8Ways(Vector2Int tilePosition)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                result.Add(tilePosition + new Vector2Int(+0, +1));
                result.Add(tilePosition + new Vector2Int(+1, +1));
                result.Add(tilePosition + new Vector2Int(+1, +0));
                result.Add(tilePosition + new Vector2Int(+1, -1));
                result.Add(tilePosition + new Vector2Int(+0, -1));
                result.Add(tilePosition + new Vector2Int(-1, -1));
                result.Add(tilePosition + new Vector2Int(-1, +0));
                result.Add(tilePosition + new Vector2Int(-1, +1));
                return result;
            }

            /// <summary>
            /// writes the 8-way neighbours into the list provided as parameter
            /// </summary>            
            public static void AdjacentToTile8Ways(Vector2Int tilePosition, List<Vector2Int> output)
            {
                output.Clear();
                output.Add(tilePosition + new Vector2Int(+0, +1));
                output.Add(tilePosition + new Vector2Int(+1, +1));
                output.Add(tilePosition + new Vector2Int(+1, +0));
                output.Add(tilePosition + new Vector2Int(+1, -1));
                output.Add(tilePosition + new Vector2Int(+0, -1));
                output.Add(tilePosition + new Vector2Int(-1, -1));
                output.Add(tilePosition + new Vector2Int(-1, +0));
                output.Add(tilePosition + new Vector2Int(-1, +1));
            }

            /// <summary>
            /// writes the 8-way neighbours into the Nativelist provided as parameter
            /// </summary>              
            public static void AdjacentToTile8Ways(int2 tilePosition, NativeList<int2> output)
            {
                output.Clear();
                output.Add(tilePosition + new int2(+0, +1));
                output.Add(tilePosition + new int2(+1, +1));
                output.Add(tilePosition + new int2(+1, +0));
                output.Add(tilePosition + new int2(+1, -1));
                output.Add(tilePosition + new int2(+0, -1));
                output.Add(tilePosition + new int2(-1, -1));
                output.Add(tilePosition + new int2(-1, +0));
                output.Add(tilePosition + new int2(-1, +1));                
            }

            /// <summary>
            /// writes the 8-way neighbours into the NativeArray provided as parameter
            /// </summary>              
            public static void AdjacentToTile8Ways(int2 tilePosition, NativeArray<int2> output)
            {                
                output[0]= tilePosition + new int2(+0, +1);
                output[1]= tilePosition + new int2(+1, +1);
                output[2]= tilePosition + new int2(+1, +0);
                output[3]= tilePosition + new int2(+1, -1);
                output[4]= tilePosition + new int2(+0, -1);
                output[5]= tilePosition + new int2(-1, -1);
                output[6]= tilePosition + new int2(-1, +0);
                output[7]= tilePosition + new int2(-1, +1);
            }

            /// <summary>
            /// returns the 4-way neighbours of the input tile
            /// </summary>            
            public static List<Vector2Int> AdjacentToTile(Vector2Int tilePosition, Vector2Int mapSize)
            {
                if(tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                List<Vector2Int> result = new List<Vector2Int>();
                if(tilePosition.y < mapSize.y - 1) result.Add(tilePosition + new Vector2Int(+0, +1));
                if(tilePosition.x < mapSize.x - 1) result.Add(tilePosition + new Vector2Int(+1, +0));
                if(tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(+0, -1));
                if(tilePosition.x > 0) result.Add(tilePosition + new Vector2Int(-1, +0));
                return result;
            }

            /// <summary>
            /// returns the valid 8-way neighbours of the input tile
            /// </summary>            
            public static List<Vector2Int> AdjacentToTile8Ways(Vector2Int tilePosition, Vector2Int mapSize)
            {
                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                List<Vector2Int> result = new List<Vector2Int>();
                if (tilePosition.y < mapSize.y - 1) result.Add(tilePosition + new Vector2Int(+0, +1));
                if (tilePosition.y < mapSize.y - 1 && tilePosition.x < mapSize.x-1) result.Add(tilePosition + new Vector2Int(+1, +1));
                if (tilePosition.x < mapSize.x - 1) result.Add(tilePosition + new Vector2Int(+1, +0));
                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(+1, -1));
                if (tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(+0, -1));
                if (tilePosition.x > 0 && tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(-1, -1));
                if (tilePosition.x > 0) result.Add(tilePosition + new Vector2Int(-1, +0));
                if (tilePosition.x < mapSize.x -1 && tilePosition.y > 0) result.Add(tilePosition + new Vector2Int(+1, -1));
                return result;
            }



            public static void AdjacentToTile8Ways(Vector2Int tilePosition, Vector2Int mapSize, List<Vector2Int> output)
            {
                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                output.Clear();
                if (tilePosition.y < mapSize.y - 1) output.Add(tilePosition + new Vector2Int(+0, +1));
                if (tilePosition.y < mapSize.y - 1 && tilePosition.x < mapSize.x - 1) output.Add(tilePosition + new Vector2Int(+1, +1));
                if (tilePosition.x < mapSize.x - 1) output.Add(tilePosition + new Vector2Int(+1, +0));
                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0) output.Add(tilePosition + new Vector2Int(+1, -1));
                if (tilePosition.y > 0) output.Add(tilePosition + new Vector2Int(+0, -1));
                if (tilePosition.x > 0 && tilePosition.y > 0) output.Add(tilePosition + new Vector2Int(-1, -1));
                if (tilePosition.x > 0) output.Add(tilePosition + new Vector2Int(-1, +0));
                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0) output.Add(tilePosition + new Vector2Int(+1, -1));
            }

            public static void AdjacentToTile8Ways(int2 tilePosition, int2 mapSize, NativeList<int2> output)
            {
                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }
                output.Clear();
                if (tilePosition.y < mapSize.y - 1) output.Add(tilePosition + new int2(+0, +1));
                if (tilePosition.y < mapSize.y - 1 && tilePosition.x < mapSize.x - 1) output.Add(tilePosition + new int2(+1, +1));
                if (tilePosition.x < mapSize.x - 1) output.Add(tilePosition + new int2(+1, +0));
                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0) output.Add(tilePosition + new int2(+1, -1));
                if (tilePosition.y > 0) output.Add(tilePosition + new int2(+0, -1));
                if (tilePosition.x > 0 && tilePosition.y > 0) output.Add(tilePosition + new int2(-1, -1));
                if (tilePosition.x > 0) output.Add(tilePosition + new int2(-1, +0));
                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0) output.Add(tilePosition + new int2(+1, -1));
            }


            /// <summary>
            /// returns the amount of valid tiles
            /// </summary>
            /// <param name="tilePosition"></param>
            /// <param name="mapSize"></param>
            /// <param name="resultArray"></param>
            /// <returns></returns>
            public static int AdjacentToTile8Ways(Vector2Int tilePosition, Vector2Int mapSize, Vector2Int[] resultArray)
            {
                int counter = 0;
                if (tilePosition.x < 0 || tilePosition.y < 0 || tilePosition.x >= mapSize.x || tilePosition.y >= mapSize.y)
                {
                    throw new System.ArgumentOutOfRangeException("tilePosition", "invalid value for input tilePosition, either <0 or higher than mapBounds in at least 1 dimension");
                }

                if (tilePosition.y < mapSize.y - 1)
                {
                    resultArray[counter]= tilePosition + new Vector2Int(+0, +1);
                    counter++;
                }

                if (tilePosition.y < mapSize.y - 1 && tilePosition.x < mapSize.x - 1)
                {
                    resultArray[counter] = tilePosition + new Vector2Int(+1, +1);
                    counter++;
                }

                if (tilePosition.x < mapSize.x - 1)
                {
                    resultArray[counter] = tilePosition + new Vector2Int(+1, +0);
                    counter++;
                }

                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0)
                {
                    resultArray[counter] =tilePosition + new Vector2Int(+1, -1);
                    counter++;
                }

                if (tilePosition.y > 0) 
                {
                    resultArray[counter] = tilePosition + new Vector2Int(+0, -1);
                    counter++;
                }

                if (tilePosition.x > 0 && tilePosition.y > 0)
                {
                    resultArray[counter] = tilePosition + new Vector2Int(-1, -1);
                    counter++;
                }

                if (tilePosition.x > 0) 
                {
                    resultArray[counter] =(tilePosition + new Vector2Int(-1, +0));
                    counter++;
                }

                if (tilePosition.x < mapSize.x - 1 && tilePosition.y > 0)
                {
                    resultArray[counter] = (tilePosition + new Vector2Int(+1, -1));
                    counter++;
                }
                return counter;
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

            public static List<Vector2Int> AdjacentToEdge(Vector2Int edgePosition, Vector2Int mapSize)
            {
                List<Vector2Int> result = new List<Vector2Int>();

                if (edgePosition.x % 2 == 0) //x value is unchanged, meaning that we have a horizontal edge
                {
                    if(edgePosition.y < ((mapSize.y*2) -2) )
                    {
                        result.Add(new Vector2Int(edgePosition.x / 2, (edgePosition.y + 1) / 2));
                    }
                    if (edgePosition.y > -1)
                    {
                        result.Add(new Vector2Int(edgePosition.x / 2, (edgePosition.y - 1) / 2));
                    }                    
                }
                else //y value is unchanged meaning we have vertical edge
                {
                    if (edgePosition.x < ((mapSize.x * 2) - 2))
                    {
                        result.Add(new Vector2Int((edgePosition.x + 1) / 2, edgePosition.y / 2));
                    }

                    if(edgePosition.x > -1 )
                    {
                        result.Add(new Vector2Int((edgePosition.x - 1) / 2, edgePosition.y / 2));
                    }                    
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

            public static List<Vector2Int> AdjacentToCorner(Vector2Int cornerPosition, Vector2Int mapSize)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                if (cornerPosition.x < ((mapSize.x * 4) - 2) && cornerPosition.y < ((mapSize.y * 4) - 2) )
                {
                    result.Add(new Vector2Int((cornerPosition.x + 2) / 4, (cornerPosition.y + 2) / 4));
                }
                
                if (cornerPosition.x < ((mapSize.x *4) -2) && cornerPosition.y > - 2)
                {
                    result.Add(new Vector2Int((cornerPosition.x + 2) / 4, (cornerPosition.y - 2) / 4));
                }
                
                if (cornerPosition.x > -2 && cornerPosition.y > -2)
                {
                    result.Add(new Vector2Int((cornerPosition.x - 2) / 4, (cornerPosition.y - 2) / 4));
                }
                if(cornerPosition.x > -2 && cornerPosition.y < ((mapSize.y*4)-2) )
                {
                    result.Add(new Vector2Int((cornerPosition.x - 2) / 4, (cornerPosition.y + 2) / 4));
                }
                
                return result;
            }

            public static List<Vector2Int> BresenhamLine(Vector2Int startPosition, Vector2Int targetPosition, bool includeOrigin)
            {
                List<Vector2Int> result = new List<Vector2Int>();

                if (startPosition.x == targetPosition.x) //vertical line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);
                    int xCoord = startPosition.x;
                    if (startPosition.y <= targetPosition.y)
                    {
                        for (int yCoord = startPosition.y + 1; yCoord <= targetPosition.y; yCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                    else
                    {
                        for (int yCoord = startPosition.y - 1; yCoord >= targetPosition.y; yCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                }
                else if (startPosition.y == targetPosition.y) // horizontal line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);
                    int yCoord = startPosition.y;

                    if (startPosition.x <= targetPosition.x)
                    {
                        for (int xCoord = startPosition.x + 1; xCoord <= targetPosition.x; xCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }

                    else
                    {
                        for (int xCoord = startPosition.x - 1; xCoord >= targetPosition.x; xCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }

                }
                //we could probably also do a special logic for lines for lines where distX == distY 

                else //general case 
                {
                    int x0 = startPosition.x;
                    int x1 = targetPosition.x;
                    int y0 = startPosition.y;
                    int y1 = targetPosition.y;

                    int dx = Mathf.Abs(x1 - x0);
                    int sx = x0 < x1 ? 1 : -1;
                    int dy = -(Mathf.Abs(y1 - y0));
                    int sy = y0 < y1 ? 1 : -1;
                    int err = dx + dy, e2; /* error value e_xy */

                    int failsafe = 0;
                    while (true && failsafe < 100000)
                    {
                        failsafe++; //should be removed
                        result.Add(new Vector2Int(x0, y0));
                        if (x0 == x1 && y0 == y1) break;
                        e2 = 2 * err;
                        if (e2 > dy) /* e_xy+e_x > 0 */
                        {
                            err += dy;
                            x0 += sx;
                        }
                        if (e2 < dx) /* e_xy+e_y < 0 */
                        {
                            err += dx;
                            y0 += sy;
                        }
                    }
                    if (!includeOrigin) result.RemoveAt(0);
                }

                return result;
            }

            public static List<Vector2Int> BresenhamLine(Vector2Int startPosition, Vector2Int targetPosition, Vector2Int mapSize, bool includeOrigin)
            {
                Debug.Assert(startPosition.x >= 0);
                Debug.Assert(startPosition.y >= 0);
                Debug.Assert(startPosition.x < mapSize.x);
                Debug.Assert(startPosition.y < mapSize.y);

                Debug.Assert(targetPosition.x >= 0);
                Debug.Assert(targetPosition.y >= 0);
                Debug.Assert(targetPosition.x < mapSize.x);
                Debug.Assert(targetPosition.y < mapSize.y);                

                List<Vector2Int> result = new List<Vector2Int>();
                
                if (startPosition.x == targetPosition.x) //vertical line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);                    
                    int xCoord = startPosition.x;
                    if(startPosition.y <= targetPosition.y)
                    {
                        for (int yCoord = startPosition.y + 1; yCoord <= targetPosition.y; yCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }                    
                    else
                    {
                        for (int yCoord = startPosition.y - 1; yCoord >= targetPosition.y; yCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                }
                else if (startPosition.y == targetPosition.y) // horizontal line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);
                    int yCoord = startPosition.y;

                    if(startPosition.x <= targetPosition.x)
                    {
                        for (int xCoord = startPosition.x + 1; xCoord <= targetPosition.x; xCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }

                    else
                    {
                        for (int xCoord = startPosition.x - 1; xCoord >= targetPosition.x; xCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }                    
                }

                //we could probably also do a special logic for lines for lines where distX == distY 

                else //general case 
                {
                    int x0 = startPosition.x;
                    int x1 = targetPosition.x;
                    int y0 = startPosition.y;
                    int y1 = targetPosition.y;

                    int dx = Mathf.Abs(x1 - x0);
                    int sx = x0 < x1 ? 1 : -1;
                    int dy = -(Mathf.Abs(y1 - y0));
                    int sy = y0 < y1 ? 1 : -1;
                    int err = dx + dy, e2; /* error value e_xy */

                    int failsafe = 0;
                    while (true && failsafe < 100000)
                    {
                        failsafe++; //should be removed
                        result.Add( new Vector2Int(x0, y0) );
                        if (x0 == x1 && y0 == y1) break;
                        e2 = 2 * err;
                        if (e2 > dy) /* e_xy+e_x > 0 */
                        {
                            err += dy;
                            x0 += sx;
                        } 
                        if (e2 < dx) /* e_xy+e_y < 0 */
                        {
                            err += dx;
                            y0 += sy; 
                        } 
                    }
                    if (!includeOrigin) result.RemoveAt(0);
                }

                return result;
            }

            public static List<Vector2Int> BresenhamLineSlope(Vector2Int startPosition, Vector2Int slope, Vector2Int mapSize, bool includeOrigin)
            {
                Debug.Assert(startPosition.x >= 0);
                Debug.Assert(startPosition.y >= 0);
                Debug.Assert(startPosition.x < mapSize.x);
                Debug.Assert(startPosition.y < mapSize.y);

                List<Vector2Int> result = new List<Vector2Int>();

                if (slope.x == 0) //vertical line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);
                    int xCoord = startPosition.x;
                    if (slope.y > 0)
                    {
                        for (int yCoord = startPosition.y + 1; yCoord < mapSize.y-1; yCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                    else
                    {
                        for (int yCoord = startPosition.y - 1; yCoord >= 0; yCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                }
                else if (slope.y == 0) // horizontal line can be handled simpler than general solution
                {
                    if (includeOrigin) result.Add(startPosition);
                    int yCoord = startPosition.y;

                    if (slope.x > 0)
                    {
                        for (int xCoord = startPosition.x + 1; xCoord < mapSize.x-1; xCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }

                    else
                    {
                        for (int xCoord = startPosition.x - 1; xCoord >= 0; xCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, yCoord));
                        }
                    }
                }

                //we could probably also do a special logic for lines for lines where distX == distY

                else //general case 
                {
                    int x0 = startPosition.x;
                    int x1 = startPosition.x + slope.x;
                    int y0 = startPosition.y;
                    int y1 = startPosition.y + slope.y;

                    int dx = Mathf.Abs(x1 - x0);
                    int sx = x0 < x1 ? 1 : -1;
                    int dy = -(Mathf.Abs(y1 - y0));
                    int sy = y0 < y1 ? 1 : -1;
                    int err = dx + dy, e2; /* error value e_xy */

                    int failsafe = 0;
                    while (true && failsafe < 100000)
                    {
                        failsafe++; //should be removed
                        if (x0 < 0 || x0 >= mapSize.x || y0 <0 || y0 >= mapSize.y) break;
                        result.Add(new Vector2Int(x0, y0));
                        e2 = 2 * err;
                        if (e2 > dy) /* e_xy+e_x > 0 */
                        {
                            err += dy;
                            x0 += sx;
                        }
                        if (e2 < dx) /* e_xy+e_y < 0 */
                        {
                            err += dx;
                            y0 += sy;
                        }
                    }
                    if (!includeOrigin) result.RemoveAt(0);
                }

                return result;
            }


            /// <summary>
            /// when "continueTilMapBounds is false, you should not pick a start or targetPosition which is right on a gridedge but offset it minimally
            /// TODO: do the offsetting ourselves
            /// </summary>                        
            public static List<Vector2Int> TraversalLine(Vector2 startPosition, Vector2 targetPosition, Vector2Int mapSize, bool includeOrigin, bool continueTilMapBounds)
            {
                List<Vector2Int> result = new List<Vector2Int>();
                var startCoord = new Vector2Int((int)startPosition.x, (int)startPosition.y);
                var targetCoord = new Vector2Int((int)targetPosition.x, (int)targetPosition.y);
                if (includeOrigin) result.Add(startCoord);

                float slopeX = targetPosition.x - startPosition.x;
                float slopeY = targetPosition.y - startPosition.y;
                Vector2 slope = new Vector2(slopeX, slopeY);
                slope.Normalize();
                Debug.Log("slope:" + slope);
                float currentDistanceToNextX;
                float currentDistanceToNextY;

                int currentX = startCoord.x;
                int currentY = startCoord.y;

                if (startCoord.x == targetCoord.x) //vertical line;
                {
                    if (slopeY > 0)
                    {
                        for (int yCoord = startCoord.y + 1; yCoord < mapSize.y - 1; yCoord++)
                        {
                            result.Add(new Vector2Int(startCoord.x, yCoord));
                        }
                    }
                    else
                    {
                        for (int yCoord = startCoord.y - 1; yCoord >= 0; yCoord--)
                        {
                            result.Add(new Vector2Int(startCoord.x, yCoord));
                        }
                    }
                }
                else if(startCoord.y == targetCoord.y) //horizontal line
                {
                    if (slopeX > 0)
                    {
                        for (int xCoord = startCoord.x + 1; xCoord < mapSize.x - 1; xCoord++)
                        {
                            result.Add(new Vector2Int(xCoord, startCoord.y));
                        }
                    }
                    else
                    {
                        for (int xCoord = startCoord.x - 1; xCoord >= 0; xCoord--)
                        {
                            result.Add(new Vector2Int(xCoord, startCoord.y));
                        }
                    }
                }

                else if(slopeX > 0 && slopeY > 0) //top right
                {
                    currentDistanceToNextX = (startCoord.x + 1) - startPosition.x;
                    currentDistanceToNextY = (startCoord.y + 1) - startPosition.y;

                    //TODO add failsafe
                    int failSafe = 0;
                    while (true)
                    {
                        if(failSafe > 10000)
                        {
                            Debug.Log("Failsafe triggered something not working as intended");
                            break;
                        }

                        if(!continueTilMapBounds && currentX == targetCoord.x && currentY == targetCoord.y)
                        {
                            break;
                        }

                        failSafe++;
                        float dist1 = currentDistanceToNextX / slope.x;
                        float dist2 = currentDistanceToNextY / slope.y;
                        if (dist1 <= dist2)
                        {
                            //we hit new X before hitting new Y
                            //calculate intersection Point:
                            currentX++;
                            if (currentX >= mapSize.x) break;
                            currentDistanceToNextX = 1;
                            currentDistanceToNextY -= dist1 * slope.y;
                            result.Add(new Vector2Int(currentX, currentY));
                        }
                        else
                        {
                            currentY++;
                            if (currentY >= mapSize.y) break;
                            currentDistanceToNextY = 1;
                            currentDistanceToNextX -= dist2 * slope.x;
                            result.Add(new Vector2Int(currentX, currentY));
                        }
                    }                                     
                }

                else if (slopeX > 0 && slopeY < 0) //bottom right
                {
                    currentDistanceToNextX = (startCoord.x + 1) - startPosition.x;
                    currentDistanceToNextY = startPosition.y - startCoord.y;

                    //TODO add failsafe
                    int failSafe = 0;
                    while (true)
                    {
                        if (failSafe > 10000)
                        {
                            Debug.Log("Failsafe triggered something not working as intended");
                            break;
                        }

                        if (!continueTilMapBounds && currentX == targetCoord.x && currentY == targetCoord.y)
                        {
                            break;
                        }

                        failSafe++;
                        float dist1 = currentDistanceToNextX / slope.x;
                        float dist2 = currentDistanceToNextY / -slope.y;
                        if (dist1 <= dist2)
                        {
                            //we hit new X before hitting new Y
                            //calculate intersection Point:
                            currentX++;
                            if (currentX >= mapSize.x) break;
                            currentDistanceToNextX = 1;
                            currentDistanceToNextY -= dist1 * -slope.y;
                            result.Add(new Vector2Int(currentX, currentY));
                        }
                        else
                        {
                            currentY--;
                            if (currentY < 0) break;
                            currentDistanceToNextY = 1;
                            currentDistanceToNextX -= dist2 * slope.x;
                            result.Add(new Vector2Int(currentX, currentY));
                        }
                    }
                }

                else if (slopeX < 0 && slopeY < 0) //bottom left
                {
                    throw new System.NotImplementedException();
                }

                else if (slopeX < 0 && slopeY > 0) //top left
                {
                    throw new System.NotImplementedException();
                }

                return result;
            }
        }
    }
}
