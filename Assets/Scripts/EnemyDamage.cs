using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    float timeToDestroy = 1f;

    private void OnParticleCollision(GameObject other)
    {

        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        // HitParticle.set
        hitParticlePrefab.Play();
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {

        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        DestroyVFX(vfx);
        Destroy(this.gameObject);

    }
    IEnumerator DestroyVFX(ParticleSystem vfx)
    {
        yield return new WaitForSeconds(1f); //this will wait 5 seconds
        Destroy(vfx.gameObject);
    }

}
