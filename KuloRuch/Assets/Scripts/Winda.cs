using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winda : MonoBehaviour
{
    public Transform[] TargetPoints;
    public float duration;
    [SerializeField] private float roadRefresh = 0.15f;
    [SerializeField] private Vector3 objectOffset = new Vector3 (0f, .5f, 0f);
    private bool isDriving = false;
    [SerializeField]private int timeBetweenDrive = 5;

    private void Start()
    {
        try
        {
            transform.position = TargetPoints[0].position;
        }
        catch
        {
            Debug.Log("Error while setting elevator");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision) && TargetPoints.Length != 0&&!isDriving)
        {
            StartCoroutine(Windowanie(collision.transform));
            isDriving = true;
        }
    }
    private IEnumerator Windowanie(Transform @object)
    {
        if (Vector3.Distance(transform.position,TargetPoints[0].position)<=1f)
        {
            int i = 1;
            @object.GetComponent<Rigidbody>().useGravity = false;
            while (i < TargetPoints.Length)
            {
                float roadRefresh_ = roadRefresh / Vector3.Distance(TargetPoints[i - 1].position, TargetPoints[i].position);
                float sek = 0;
                while (transform.position != TargetPoints[i].position)
                {
                    sek += roadRefresh_;
                    @object.position = transform.position + objectOffset;
                    transform.position = Vector3.Lerp(TargetPoints[i - 1].position, TargetPoints[i].position, sek / duration);
                    @object.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    yield return new WaitForSeconds(roadRefresh_);
                }
                i++;
                Debug.Log(i);
            }
            @object.GetComponent<Rigidbody>().useGravity = true;
            @object.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("We end with: "+i);
        }
        else if (Vector3.Distance(transform.position, TargetPoints[TargetPoints.Length-1].position)<=1f)
        {
            int i = TargetPoints.Length - 2;
            @object.GetComponent<Rigidbody>().useGravity = false;
            while (i >=0)
            {
                float roadRefresh_ = roadRefresh / Vector3.Distance(TargetPoints[i + 1].position, TargetPoints[i].position);
                float sek = 0;
                while (transform.position != TargetPoints[i].position)
                {

                    sek += roadRefresh_;
                    @object.position = transform.position + objectOffset;
                    transform.position = Vector3.Lerp(TargetPoints[i + 1].position, TargetPoints[i].position, sek / duration);
                    @object.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    yield return new WaitForSeconds(roadRefresh_);
                }
                i--;
                Debug.Log(i);
            }
            @object.GetComponent<Rigidbody>().useGravity = true;
            @object.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("We end with: " + i);
        }

        int _timeBetweenDrive = timeBetweenDrive;
        while (_timeBetweenDrive > 0)
        {
            _timeBetweenDrive--;
            yield return new WaitForSeconds(1f);
        }
        isDriving = false;
    }
    
}
