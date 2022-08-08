using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winda : MonoBehaviour
{
    public Transform[] TargetPoints;
    public float duration;
    [SerializeField] bool CanGoBack = true;
    [SerializeField]private bool isRotating;
    [SerializeField] private bool isTakingPlayer = true;
    [Space]
    [SerializeField] private float roadRefresh = 0.15f;
    [SerializeField] private Vector3 objectOffset = new Vector3 (0f, .5f, 0f);
    private bool isDriving = false;
    [SerializeField]private int timeBetweenDrive = 5;

    IWindaAdd[] additions;

    private void Start()
    {
        if (TargetPoints.Length==0)
        {
            Debug.LogError("No points selected for: " + gameObject.name + $" at {transform.position.x}, {transform.position.y}, {transform.position.z}!");
            Destroy(gameObject);
            return;
        }
        try
        {
            transform.position = TargetPoints[0].position;
        }
        catch
        {
            Debug.Log("Error while setting elevator");
        }

        additions=GetComponents<IWindaAdd>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision) && TargetPoints.Length != 0&&!isDriving)
        {
            if (additions.Length!=0)
            {
                foreach (IWindaAdd item in additions)
                {
                    item.OnStart();
                }
            }
            if (isTakingPlayer)
            {
            StartCoroutine(Windowanie(collision.transform));
            }
            else
            {
                StartCoroutine(Windowanie());
            }
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
                    if (isRotating)
                    {
                        transform.rotation = Quaternion.Lerp(TargetPoints[i - 1].rotation, TargetPoints[i].rotation, sek / duration);
                    }
                    yield return new WaitForSeconds(roadRefresh_);
                }
                i++;
                Debug.Log(i);
                if (additions.Length != 0)
                {
                    foreach (IWindaAdd item in additions)
                    {
                        item.OnUpdate();
                    }
                }
            }
            @object.GetComponent<Rigidbody>().useGravity = true;
            @object.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (additions.Length != 0)
            {
                foreach (IWindaAdd item in additions)
                {
                    item.OnStop();
                }
            }
            Debug.Log("We end with: "+i);
        }
        else if (Vector3.Distance(transform.position, TargetPoints[TargetPoints.Length-1].position)<=1f &&CanGoBack)
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
    public IEnumerator Windowanie()
    {
        if (Vector3.Distance(transform.position,TargetPoints[0].position)<=1f)
        {
            int i = 1;
            while (i < TargetPoints.Length)
            {
                float roadRefresh_ = roadRefresh / Vector3.Distance(TargetPoints[i - 1].position, TargetPoints[i].position);
                float sek = 0;
                while (transform.position != TargetPoints[i].position)
                {
                    sek += roadRefresh_;
                    
                    transform.position = Vector3.Lerp(TargetPoints[i - 1].position, TargetPoints[i].position, sek / duration);
                    
                    if (isRotating)
                    {
                        transform.rotation = Quaternion.Lerp(TargetPoints[i - 1].rotation, TargetPoints[i].rotation, sek / duration);
                    }
                    yield return new WaitForSeconds(roadRefresh_);
                }
                i++;
                Debug.Log(i);
                if (additions.Length != 0)
                {
                    foreach (IWindaAdd item in additions)
                    {
                        item.OnUpdate();
                    }
                }
            }
            
            
            if (additions.Length != 0)
            {
                foreach (IWindaAdd item in additions)
                {
                    item.OnStop();
                }
            }
            Debug.Log("We end with: "+i);
        }
        else if (Vector3.Distance(transform.position, TargetPoints[TargetPoints.Length-1].position)<=1f&&CanGoBack)
        {
            int i = TargetPoints.Length - 2;
            
            while (i >=0)
            {
                float roadRefresh_ = roadRefresh / Vector3.Distance(TargetPoints[i + 1].position, TargetPoints[i].position);
                float sek = 0;
                while (transform.position != TargetPoints[i].position)
                {

                    sek += roadRefresh_;
                    
                    transform.position = Vector3.Lerp(TargetPoints[i + 1].position, TargetPoints[i].position, sek / duration);
                    
                    yield return new WaitForSeconds(roadRefresh_);
                }
                i--;
                Debug.Log(i);
            }
            
            
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
