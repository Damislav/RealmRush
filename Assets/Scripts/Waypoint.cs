using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // [SerializeField] Color exploredColor;

    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver()
    {
        var input = Input.GetMouseButton(0);
        if (input)
        {
            if (isPlaceable)
            {

                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Cant place it here");
            }


        }

    }


    // for coloring top
    // public void SetTopColor(Color color)
    // {
    //     MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    //     topMeshRenderer.material.color = color;
    // }

    // consider setting own color in Update()
    // private void Update()
    // {
    //     if (isExplored)
    //     {
    //         SetTopColor(Color.green);
    //     }
    //     else

    //     {

    //         SetTopColor(Color.white);
    //     }
    // }

}