using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameButtonScript))]
public class DoorOpener : MonoBehaviour, IClick
{
    private Vector3 startPosition;
    private Vector3 startRotation;
    [SerializeField] private Transform Door;
    [SerializeField]private Vector3 endPosition;
    [SerializeField] private Vector3 TargetRotation;
    [Range(0.001f,1f)]public float doorMove = .1f;
    bool isOpen;

    private void Start()
    {
        startPosition = Door.position;
        endPosition = Door.position+endPosition;

        startRotation = Door.rotation.eulerAngles;
        TargetRotation = startRotation + TargetRotation;
    }

    public void Click()
    {
        StartCoroutine(MoveDoors());
    }

    IEnumerator MoveDoors()
    {
        float x = 0f;
        if (isOpen)
        {
            while (Door.position != startPosition)
            {
                Door.position = Vector3.LerpUnclamped(endPosition, startPosition, x);
                Door.rotation = Quaternion.LerpUnclamped(Quaternion.Euler(TargetRotation), Quaternion.Euler(startRotation), x);
                x += doorMove;
                yield return new WaitForSeconds(.2f);
            }
        }
        else
        {
            while (Door.position != endPosition)
            {
                Door.position = Vector3.LerpUnclamped(startPosition, endPosition, x);
                Door.rotation = Quaternion.LerpUnclamped(Quaternion.Euler(startRotation), Quaternion.Euler(TargetRotation), x);
                x += doorMove;
                yield return new WaitForSeconds(.2f);
            }
        }
        isOpen = !isOpen;
    }

    private void OnDrawGizmosSelected()
    {
        if (Door!=null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Door.position,.25f);
            Gizmos.color= Color.red;
            Gizmos.DrawWireCube(Door.position + endPosition,new Vector3(.25f,.25f,.25f));
        }
    }
}
