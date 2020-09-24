using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    void Start()
    {
        
    }

    public int ReturnGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGrid()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    /*   public void SetTopColor(Color color)
       {
           MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
           topMeshRenderer.material.color = color;
       }*/
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
                
            }
            
        }
        
        
    }
}
