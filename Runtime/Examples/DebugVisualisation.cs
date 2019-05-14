using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.QuadMapLibrary;

namespace Wunderwunsch.QuadMapLibrary.Examples
{
    public class DebugVisualisation : MonoBehaviour
    {
        [SerializeField] GameObject tilePrefab;
        [SerializeField] GameObject tileMarker;
        [SerializeField] GameObject edgePrefab;
        [SerializeField] GameObject cornerPrefab;
        [SerializeField] Vector2Int mapSize;

        // Start is called before the first frame update
        void Start()
        {
            for(int y = 0; y <mapSize.y; y++)
            {
                for(int x = 0; x < mapSize.x; x++)
                {
                    var instance = GameObject.Instantiate(tilePrefab);
                    instance.transform.position = new Vector3(x, 0, y);
                }
            }

            var result = QuadGrid.GetTiles.AdjacentToTile(new Vector2Int(0, mapSize.y / 4), mapSize);
            foreach(var r in result)
            {
                var instance = GameObject.Instantiate(tileMarker);
                instance.transform.position = new Vector3(r.x, .1f, r.y);                
            }
            //
            //result = QuadGrid.GetTiles.AdjacentToTile(new Vector2Int(mapSize.x-1, mapSize.y-1), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //
            //}
            //
            //result = QuadGrid.GetCorners.AdjacentToTile(new Vector2Int(0, 0));
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(cornerPrefab);
            //    instance.transform.position = new Vector3(r.x/4f, .1f, r.y/4f);
            //
            //}
            //
            //result = QuadGrid.GetCorners.AdjacentToTile(new Vector2Int(3, 3));
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(cornerPrefab);
            //    instance.transform.position = new Vector3(r.x / 4f, .1f, r.y / 4f);
            //}
            //
            //result = QuadGrid.GetEdges.AdjacentToTile(new Vector2Int(3, 3));
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(edgePrefab);
            //    instance.transform.position = new Vector3(r.x / 2f, .1f, r.y / 2f);
            //    if (QuadGrid.IsVerticalEdge(r))
            //    {
            //        instance.transform.localScale = new Vector3(.1f, .3f, 1f);
            //    }
            //    else instance.transform.localScale = new Vector3(1f, .3f, .1f);
            //}
            //
            //result = QuadGrid.GetEdges.AdjacentToTile(new Vector2Int(mapSize.x-1, 0));
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(edgePrefab);
            //    instance.transform.position = new Vector3(r.x / 2f, .1f, r.y / 2f);
            //    if (QuadGrid.IsVerticalEdge(r))
            //    {
            //        instance.transform.localScale = new Vector3(.1f, .3f, 1f);
            //    }
            //    else instance.transform.localScale = new Vector3(1f, .3f, .1f);
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToEdge(new Vector2Int(-1, 6), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToEdge(new Vector2Int(12, -1), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToEdge(new Vector2Int(12, ((mapSize.y*2)-1)), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToCorner(new Vector2Int(-2, -2), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToCorner(new Vector2Int(-2, (mapSize.y*4)-2), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToCorner(new Vector2Int(62, (mapSize.y * 4) - 2), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToCorner(new Vector2Int((mapSize.x * 4) - 2,34), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.AdjacentToCorner(new Vector2Int(38, 42), mapSize);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(2, 2), new Vector2Int(2, 5), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(4, 8), new Vector2Int(4, 4), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(8, 8), new Vector2Int(15, 8), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(10, 10), new Vector2Int(-10, 10), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(9, 6), new Vector2Int(9, -6), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLine(new Vector2Int(-13, 12), new Vector2Int(9, -4), true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}

            //result = QuadGrid.GetTiles.BresenhamLineSlope(new Vector2Int(0, 0), new Vector2Int(2, 0),mapSize,true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}
            //
            //result = QuadGrid.GetTiles.BresenhamLineSlope(new Vector2Int(4, 0), new Vector2Int(0, 2), mapSize, true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}

            //result = QuadGrid.GetTiles.BresenhamLineSlope(new Vector2Int(6, 2), new Vector2Int(1, 1), mapSize, true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}

            //result = QuadGrid.GetTiles.BresenhamLineSlope(new Vector2Int(8, 5), new Vector2Int(-4, 1), mapSize, true);
            //foreach (var r in result)
            //{
            //    var instance = GameObject.Instantiate(tileMarker);
            //    instance.transform.position = new Vector3(r.x, .1f, r.y);
            //}

            result = QuadGrid.GetTiles.TraversalLine(new Vector2(7.5f,14.5f), new Vector2(4f, 17f), mapSize, true,true);
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(tileMarker);
                instance.transform.position = new Vector3(r.x, .1f, r.y);
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
