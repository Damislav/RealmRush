using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn;
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // forever
        {
            //spawn enemy 
            RepeatedlySpawnEnemies();
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }


    }
    private void RepeatedlySpawnEnemies()
    {
        // Instantiate the prefab at the desired position and rotation
        GameObject prefab = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform);
    }
}
