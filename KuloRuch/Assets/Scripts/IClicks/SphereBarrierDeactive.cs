using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameButtonScript))]
public class SphereBarrierDeactive : MonoBehaviour, IClick
{
    [SerializeField] ShieldBarrier barrier;
    [SerializeField] GameObject[] VFX;
    public void Click()
    {
        barrier.PowerSources--;
        foreach (GameObject item in VFX)
        {
            Destroy(item);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (barrier!=null)
        {
            return;
        }
       barrier= FindObjectOfType<ShieldBarrier>();
        if (barrier==null)
        {
            Debug.LogError("There isn't any barriers!");
            Destroy(this);
        }
    }
}
