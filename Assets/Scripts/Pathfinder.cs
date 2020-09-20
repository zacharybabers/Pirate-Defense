using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    
    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;
    private Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>();

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
        {
            if (path.Count == 0)
            {
                CalculatePath();
                return path;
            }
            else
            {
                return path;
            }
           
        }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
        {
            path.Add(endWaypoint);

            Waypoint previous = endWaypoint.exploredFrom;
            while (previous != startWaypoint)
            {
                path.Add(previous);
                previous = previous.exploredFrom;

            }
            
            path.Add(startWaypoint);
            path.Reverse();
        }

        private void BreadthFirstSearch()
        {
            queue.Enqueue(startWaypoint);

            while (queue.Count > 0 && isRunning)
            {
                searchCenter = queue.Dequeue();
                HaltIfEndFound(searchCenter);
                ExploreNeighbours();
                searchCenter.isExplored = true;
            }
            print("Finished pathfinding?");
        }


        private void HaltIfEndFound(Waypoint searchCenter)
        {
            if (searchCenter == endWaypoint)
            {
                isRunning = false;
            }
        }
        private void ExploreNeighbours()
        {
            if (!isRunning) { return; }
            
            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
                if (grid.ContainsKey(neighbourCoordinates))
                {
                    QueueNewNeighbours(neighbourCoordinates);
                }
            }
        }

        private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
        {
            Waypoint neighbour = grid[neighbourCoordinates];
            if (neighbour.isExplored || queue.Contains(neighbour))
            {
                //do nothing
            }
            else
            {
                queue.Enqueue(neighbour);
                neighbour.exploredFrom = searchCenter;
            }
        }

        private void ColorStartAndEnd()
        {
            startWaypoint.SetTopColor(Color.green);
            endWaypoint.SetTopColor(Color.red);
        }
        
        private void LoadBlocks()
        {
            var waypoints = FindObjectsOfType<Waypoint>();
            foreach (Waypoint waypoint in waypoints)
            {
                var gridPos = waypoint.GetGridPos();
                if (grid.ContainsKey(gridPos))
                {
                    Debug.LogWarning("Skipping overlapping block " + waypoint);
                }
                else
                {
                    grid.Add(gridPos, waypoint);
                }
            }
        }
}
