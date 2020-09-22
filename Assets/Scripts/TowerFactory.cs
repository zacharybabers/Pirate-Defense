using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower tower;
    [SerializeField] private float towerHeight = 5f;

    private int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void MoveExistingTower()
    {
        Debug.Log("Max towers reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(tower,
            new Vector3(baseWaypoint.transform.position.x, (baseWaypoint.transform.position.y + towerHeight),
                baseWaypoint.transform.position.z), Quaternion.identity);
        baseWaypoint.hasTower = true;
        numTowers++;
    }
}
