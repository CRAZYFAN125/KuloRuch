using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarrier : MonoBehaviour
{
    [SerializeField] private string TargetTag;
    private GameObject Target;
    private Material mat;
    [SerializeField] private string variable = "_SphereCenter";

    IBarrierOff[] barrierOffs;

    public int PowerSources = 4;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag(TargetTag);
        mat = GetComponent<Renderer>().material;

        barrierOffs = gameObject.GetComponents<IBarrierOff>();
    }
    void Update()
    {
        mat.SetVector(variable, Target.transform.position);
        if (PowerSources<=0)
        {
            if (barrierOffs.Length>0)
            {
                foreach (IBarrierOff item in barrierOffs)
                {
                    item.Run();
                }
            }
            Destroy(transform.parent.gameObject,.1f);
        }
    }
}
