using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Header("Snap to cube-grid of width gridSize.")]
    [SerializeField][Range(1f, 20f)] float gridSize = 10f;


    TextMeshPro textMesh;
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
            Vector3 snapPos;
            snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
            snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
            transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

            textMesh = GetComponentInChildren<TextMeshPro>();
            string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
            textMesh.text = labelText;
            //make Objects in editor have name as label
            gameObject.name = labelText;

        }
    }

}
