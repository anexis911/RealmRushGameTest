using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isSpawning = true;
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyToPrefab = null;
    void Start()
    {
        
        StartCoroutine(SpwaningEnemies());
    }

    IEnumerator SpwaningEnemies()
    {
        while(isSpawning) {
            print("Spawned!");
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        
    }
}
