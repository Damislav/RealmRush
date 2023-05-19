using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Start()
    {
        // Manually enable this component whenever you need it in edit mode,
        // leave disabled during the game and for the final build.
        this.enabled = true;
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            SnapToGrid();
            UpdateLabel();
        }
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {
        TextMeshPro textMesh = GetComponentInChildren<TextMeshPro>();
        string labelText =
            waypoint.GetGridPos().x +
            "," +
            waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}