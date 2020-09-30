using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower tower;
    [SerializeField] private float towerHeight = 5f;

    [SerializeField] private Transform towerParentTransform;
    //create empty queue of towers
    Queue<Tower> towerQueue =  new Queue<Tower>();

    private int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        numTowers = towerQueue.Count;
        
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        //set the placeable flags
        oldTower.baseWaypoint.hasTower = false;
        newBaseWaypoint.hasTower = true;
        //set the baseWaypoints
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position + new Vector3(0,towerHeight, 0);
        towerQueue.Enqueue(oldTower);
    }
    
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(tower, baseWaypoint.transform.position + new Vector3(0, towerHeight, 0), Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.hasTower = true;
        
        //set the baseWaypoints
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.hasTower = true;
        
        towerQueue.Enqueue(newTower);
        
    }
}
