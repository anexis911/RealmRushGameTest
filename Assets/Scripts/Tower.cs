﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetEnemy = null;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectilePArticle = null;

    // Update is called once per frame
    void Update()
    {
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