using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDAmage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle = null;
    [SerializeField] ParticleSystem deathPArticle = null;
    [SerializeField] AudioClip deathSFX = null;
    [SerializeField] AudioClip hitSFX = null;

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

    public void KillEnemy()
    {
        var deathPart = Instantiate(deathPArticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        deathPart.Play();
        float destrDelay = deathPart.main.duration;
        Destroy(deathPart.gameObject, destrDelay);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticle.Play();
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);

    }
}
