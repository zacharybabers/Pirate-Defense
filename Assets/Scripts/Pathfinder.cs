using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    
    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] private bool isRunning = true; //todo make private

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

        void Start()
        {
            LoadBlocks();
            ColorStartAndEnd();
            Pathfind();
        }

        private void Pathfind()
        {
            queue.Enqueue(startWaypoint);

            while (queue.Count > 0 && isRunning)
            {
                var searchCenter = queue.Dequeue();
                searchCenter.isExplored = true;
                print("Searching from " + searchCenter); // todo remove log
                HaltIfEndFound(searchCenter);
                ExploreNeighbours(searchCenter);
            }
            print("Finished pathfinding?");
        }


        private void HaltIfEndFound(Waypoint searchCenter)
        {
            if (searchCenter == endWaypoint)
            {
                print("Searching from end node, therefore stopping"); // todo remove log 
                isRunning = false;
            }
        }
        private void ExploreNeighbours(Waypoint from)
        {
            if (!isRunning) { return; }
            
            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
                try
                {
                    QueueNewNeighbours(neighbourCoordinates);
                }
                catch
                {
                    //do nothing
                }
            }
        }

        private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
        {
            Waypoint neighbour = grid[neighbourCoordinates];
            if (neighbour.isExplored)
            {
                //do nothing
            }
            else
            {
                grid[neighbourCoordinates].SetTopColor(Color.blue); // todo move later
                queue.Enqueue(grid[neighbourCoordinates]);
                print("Queueing " + neighbour);
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

        // Update is called once per frame
    void Update()
    {
        
    }
}
