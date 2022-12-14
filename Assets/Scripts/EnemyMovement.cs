using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float waypointWaitTime = 1f;
    [SerializeField] private float waypointMoveTime = 1f;
    [SerializeField] private ParticleSystem goalParticlePrefab;
    
    private Pathfinder currentPathfinder;
   
    
   void Start()
   {
    Pathfinder pathfinder = FindPathfinder();
    var path = pathfinder.GetPath();
    StartCoroutine(FollowPath(path));
   }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        transform.position = path[0].transform.position;
       foreach (Waypoint waypoint in path)
       {
           for (int i = 0; i < 100; i++) 
           {
               transform.position = Vector3.Lerp((transform.position), waypoint.transform.position, i/100f);
               yield return new WaitForSeconds(waypointMoveTime / 100f);
           }
           transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waypointWaitTime);
       }
       SelfDestruct();
    }
    
    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        vfx.Play();
        Destroy(gameObject, 0.1f);
    }

    private Pathfinder FindPathfinder()
    {
        var allPathfinders = FindObjectsOfType<Pathfinder>();
        foreach (Pathfinder pathfinder in allPathfinders)
        {
            if (currentPathfinder == null)
            {
                currentPathfinder = pathfinder;
            }
            else
            {
                if (Vector3.Distance(transform.position, pathfinder.startWaypoint.transform.position) < Vector3.Distance(transform.position, currentPathfinder.startWaypoint.transform.position))
                {
                    currentPathfinder = pathfinder;
                }
            
            }
        }

        return currentPathfinder;
    }
    
   
}
