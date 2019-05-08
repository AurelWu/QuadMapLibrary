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

            result = QuadGrid.GetTiles.AdjacentToTile(new Vector2Int(mapSize.x-1, mapSize.y-1), mapSize);
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(tileMarker);
                instance.transform.position = new Vector3(r.x, .1f, r.y);

            }

            result = QuadGrid.GetCorners.AdjacentToTile(new Vector2Int(0, 0));
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(cornerPrefab);
                instance.transform.position = new Vector3(r.x/4f, .1f, r.y/4f);

            }

            result = QuadGrid.GetCorners.AdjacentToTile(new Vector2Int(3, 3));
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(cornerPrefab);
                instance.transform.position = new Vector3(r.x / 4f, .1f, r.y / 4f);
            }

            result = QuadGrid.GetEdges.AdjacentToTile(new Vector2Int(3, 3));
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(edgePrefab);
                instance.transform.position = new Vector3(r.x / 2f, .1f, r.y / 2f);
                if (QuadGrid.IsVerticalEdge(r))
                {
                    instance.transform.localScale = new Vector3(.1f, .3f, 1f);
                }
                else instance.transform.localScale = new Vector3(1f, .3f, .1f);
            }

            result = QuadGrid.GetEdges.AdjacentToTile(new Vector2Int(mapSize.x-1, 0));
            foreach (var r in result)
            {
                var instance = GameObject.Instantiate(edgePrefab);
                instance.transform.position = new Vector3(r.x / 2f, .1f, r.y / 2f);
                if (QuadGrid.IsVerticalEdge(r))
                {
                    instance.transform.localScale = new Vector3(.1f, .3f, 1f);
                }
                else instance.transform.localScale = new Vector3(1f, .3f, .1f);
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
