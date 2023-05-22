using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;


    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    public void ProcessHit()
    {

        // HitParticle.set
        hitParticlePrefab.Play();
        hitPoints = hitPoints - 1;
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    public void KillEnemy()
    {

        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx
        .main.duration;

        //destroy particle after delay
        Destroy(vfx.gameObject, destroyDelay); //particles

        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera
        .main.transform.position);

        Destroy(gameObject);// enemy
    }


}
