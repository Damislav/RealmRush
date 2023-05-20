using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameter of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

    // can change
    Transform targetEnemy;


    private void Update()
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
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy.transform, testEnemy.transform);

        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transformA.position, transform.position);
        var distToB = Vector3.Distance(transformB.position, transform.position);

        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
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
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }




}
