using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Wunderwunsch.QuadMapLibrary;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Burst;

public class Benchmark : MonoBehaviour
{
    [SerializeField] Text textField;
    // Start is called before the first frame update
    void Start()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        List<Vector2Int> result = new List<Vector2Int>(); ;
        Vector2Int[] resArray = new Vector2Int[8];
        for(int i = 0; i < 1000000; i++)
        {
             result = QuadGrid.GetTiles.AdjacentToTile8Ways(new Vector2Int(1,1), new Vector2Int(20, 20));
        }
        watch.Stop();
        textField.text+= ("returning new list version: " + watch.ElapsedMilliseconds);

        watch.Restart();        
        for (int i = 0; i < 1000000; i++)
        {
            QuadGrid.GetTiles.AdjacentToTile8Ways(new Vector2Int(1,1), new Vector2Int(20, 20),result);
        }
        watch.Stop();
        textField.text += ("\r\nwrite into existing list version after clearing it: " + watch.ElapsedMilliseconds);

        watch.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            int amount = QuadGrid.GetTiles.AdjacentToTile8Ways(new Vector2Int(1,1), new Vector2Int(20, 20), resArray);
        }
        watch.Stop();
        textField.text += ("\r\nwrite into array and keep version: " + watch.ElapsedMilliseconds);

        var output = new NativeList<int2>(8, Allocator.Persistent);
        var outputArray = new NativeArray<int2>(8, Allocator.Persistent);

        watch.Restart();
        var job = new Benchmark8WayJob
        {
            tilePosition = new int2(1, 1),
            mapSize = new int2(20, 20),
            result = output
        };
        job.Schedule().Complete();
        watch.Stop();
        textField.text += ("\r\njobified/burst version: " + watch.ElapsedMilliseconds);
        output.Dispose();

        watch.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            result = QuadGrid.GetTiles.AdjacentToTile8Ways(Vector2Int.zero);
        }
        watch.Stop();
        textField.text += ("\r\nreturning new list, no bound checks: " + watch.ElapsedMilliseconds);

        watch.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            QuadGrid.GetTiles.AdjacentToTile8Ways(Vector2Int.zero,result);
        }
        watch.Stop();
        textField.text += ("\r\nwriting into existing list, no bound checks: " + watch.ElapsedMilliseconds);

        watch.Restart();
        var njob = new Benchmark8WayJobNoBoundCheck()
        {
            tilePosition = new int2(1, 1),
            mapSize = new int2(20, 20),
            result = outputArray
        };
        njob.Schedule().Complete();
        watch.Stop();
        textField.text += ("\r\njobified/burst version, array, no bound checks: " + watch.ElapsedMilliseconds);
        outputArray.Dispose();
    }
    
    [BurstCompile]
    private struct Benchmark8WayJob : IJob
    {
        [ReadOnly]
        public int2 tilePosition;
        [ReadOnly]
        public int2 mapSize;
        public NativeList<int2> result;

        public void Execute()
        {
            for (int i = 0; i < 1000000; i++)
            {
                QuadGrid.GetTiles.AdjacentToTile8Ways(tilePosition, mapSize, result);
            }
        }
    }

    [BurstCompile]
    private struct Benchmark8WayJobNoBoundCheck : IJob
    {
        [ReadOnly]
        public int2 tilePosition;
        [ReadOnly]
        public int2 mapSize;
        public NativeArray<int2> result;

        public void Execute()
        {
            for (int i = 0; i < 1000000; i++)
            {
                QuadGrid.GetTiles.AdjacentToTile8Ways(tilePosition,result);
            }
        }
    }
}
