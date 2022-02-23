using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionViever : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private Color GizmosColor = new Color(0, 0, 0, 255);
    [SerializeField] private Vector3 scale = new Vector3(1,1,0.2f);

    private void OnDrawGizmos()
    {
        if (game!=null)
        {
            Gizmos.color = GizmosColor;
            Gizmos.DrawWireMesh(game.GetComponent<MeshFilter>().sharedMesh ,transform.position, game.transform.rotation, scale);
        }
    }
}
