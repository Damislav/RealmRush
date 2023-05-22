using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // [SerializeField] List<Waypoint> path;// to see enemy path ## todo remove 
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;

            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();


    }
    private void SelfDestruct()
    {

        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx
        .main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
