using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    public bool isSpawning = true;
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyToPrefab = null;
    [SerializeField] Text spawnedEnemies = null;
    [SerializeField] AudioClip spawnedEnemySFX = null;
    int score = 0;
    void Start()
    {
        
        StartCoroutine(SpwaningEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator SpwaningEnemies()
    {
        while(isSpawning) {
            score++;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            spawnedEnemies.text = score.ToString();
            var enemyPref =  Instantiate(enemyToPrefab, transform.position, Quaternion.identity);
            enemyPref.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        
    }
}
