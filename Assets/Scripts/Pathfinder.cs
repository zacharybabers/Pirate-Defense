using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    
    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

        void Start()
        {
            LoadBlocks();
            ColorStartAndEnd();
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
