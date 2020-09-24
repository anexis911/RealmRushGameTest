using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint=null, endWaypoint = null;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>(); 

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    void Start()
    {

    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            //ColorStartAndEnd();
            BreathFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceable = false;
        Waypoint previous = endWaypoint.exploredFrom;
        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
        startWaypoint.isPlaceable = false;
        
    }

    private void BreathFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();

            HaltIfEndPoint();
            ExploreNeighbours();
            searchCenter.isExplored = true;

        }
    }

    private void HaltIfEndPoint()
    {
        if (searchCenter == endWaypoint)
        {
           
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        else
        {
            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighborCoordinates = searchCenter.GetGrid() + direction;
                if (grid.ContainsKey(neighborCoordinates))
                {
                    QueueNewNeighbors(neighborCoordinates);
                }
            }
        }

        
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor)) 
        {
            //do nothing
        }
        else
        {
               queue.Enqueue(neighbor);
               neighbor.exploredFrom = searchCenter;
         }
    }

   /* private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.white);
        endWaypoint.SetTopColor(Color.grey);
    }*/

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOVerlaping = grid.ContainsKey(waypoint.GetGrid());
            if (isOVerlaping)
            {
                Debug.LogWarning("Overlapping tiles!" + waypoint.name);
            }
            else
            {
                grid.Add(waypoint.GetGrid(), waypoint);
                               
            }
                       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
