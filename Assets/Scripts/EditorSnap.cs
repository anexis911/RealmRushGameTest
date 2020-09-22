using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]

public class EditorSnap : MonoBehaviour
{


    



    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();





    }

    private void SnapToGrid()
    {

        int gridSize = waypoint.ReturnGridSize();
        
        
        transform.position = new Vector3(waypoint.GetGrid().x * gridSize, 0f, waypoint.GetGrid().y* gridSize);
    }

    private void UpdateLabel()

    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGrid().x + "," + waypoint.GetGrid().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
