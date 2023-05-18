using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    [SerializeField] float dwellTime = 1f;

    private void Start()
    {
        StartCoroutine(PrintAllWaypoints());
        Debug.Log("Hey im at the start");
    }

    IEnumerator PrintAllWaypoints()
    {
        Debug.Log("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Visiting " + transform.position);
            yield return new WaitForSeconds(dwellTime);
        }
        Debug.Log("Ending Patrol");
        path.Reverse();
        Debug.Log("Now going backwards");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Visiting " + transform.position);
            yield return new WaitForSeconds(dwellTime);
        }
        Debug.Log("Finished loop");
    }


}
