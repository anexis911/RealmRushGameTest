using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetEnemy = null;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectilePArticle = null;

    public Waypoint baseWaipoint;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDAmage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDAmage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
    {
        var distToA = Vector3.Distance(transform.position, closestEnemy.position);
        var distB = Vector3.Distance(transform.position, testEnemy.position);
        if (distToA < distB)
        {
            return closestEnemy;
        }
        return testEnemy;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }

    }
    private void Shoot(bool isActive)
    {
        var emissionModule = projectilePArticle.emission;
        emissionModule.enabled = isActive;
    }
}
