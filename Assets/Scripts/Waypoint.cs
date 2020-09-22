using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    private bool hasTower;
    
    private Vector2Int gridPos;
    
    private const int gridSize = 10;

    [SerializeField] private Tower tower;
    [SerializeField] private float towerHeight = 5f;
    

    public int GetGridSize()
    {
        return (gridSize);
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize) 
        );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            if (isPlaceable && hasTower == false)
            {
                Instantiate(tower, new Vector3(transform.position.x, (transform.position.y + towerHeight), transform.position.z), Quaternion.identity);
                hasTower = true;
            }
            else
            {
                print("Clicked (NOT PLACEABLE) on " + gameObject.name);
            }
       
    }
}
