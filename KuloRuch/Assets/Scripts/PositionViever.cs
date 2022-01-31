using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionViever : MonoBehaviour
{
    [SerializeField] private GameObject game;

    private void OnDrawGizmos()
    {
        if (game!=null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireMesh(game.GetComponent<MeshFilter>().sharedMesh ,transform.position, game.transform.rotation, game.transform.localScale);
        }
    }
}
