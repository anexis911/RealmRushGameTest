using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDAmage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {

        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        print("Curr hp is" + hitPoints);
    }
}
