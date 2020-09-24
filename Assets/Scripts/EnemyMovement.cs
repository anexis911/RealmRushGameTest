using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float enemySpeed = 0.5f;
    EnemyDAmage enemyDAmage;


    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        enemyDAmage = FindObjectOfType<EnemyDAmage>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
        

    }
    
    IEnumerator FollowPath(List<Waypoint> path)
    {

        //Debug.Log("Starting patroll");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(enemySpeed);
        }
        enemyDAmage.KillEnemy();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
