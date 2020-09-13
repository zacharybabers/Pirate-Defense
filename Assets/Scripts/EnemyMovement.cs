using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> path;
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("visiting " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
