using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
        

    }
    
    IEnumerator FollowPath(List<Waypoint> path)
    {

        Debug.Log("Starting patroll");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2);
        }
        Debug.Log("Ending patroll");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
