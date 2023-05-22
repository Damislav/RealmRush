using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    Queue<Tower> towerQueue = new Queue<Tower>();

    [SerializeField] int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    // create an empty queue of towers
    public void AddTower(Waypoint baseWaypoint)
    {
        Debug.Log(towerQueue.Count);
        int numTower = towerQueue.Count;

        if (numTower < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        //set the basewaypoints
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        // put new tower on the queue
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        //take bottom of queue
        var oldTower = towerQueue.Dequeue();

        // set placelabe flags
        oldTower.baseWaypoint.isPlaceable = true; // free up the block
        newBaseWaypoint.isPlaceable = false; // new current block is occupied

        //set the basewaypoints
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        // put the old tower on the top of the queu
        towerQueue.Enqueue(oldTower);
    }

}
