using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab = null;
    [SerializeField] GameObject towerParentTransform = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void MoveExistingTower(Waypoint newbaseWaipoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaipoint.isPlaceable = true;
        newbaseWaipoint.isPlaceable = false;
        oldTower.baseWaipoint = newbaseWaipoint;
        oldTower.transform.position = newbaseWaipoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWaipoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }
}
