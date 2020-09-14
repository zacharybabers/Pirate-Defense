using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false; // ok as is a data class
    private Vector2Int gridPos;
    
    private const int gridSize = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void SetTopColor(Color color)
    {
       MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
       topMeshRenderer.material.color = color;
    }
}
