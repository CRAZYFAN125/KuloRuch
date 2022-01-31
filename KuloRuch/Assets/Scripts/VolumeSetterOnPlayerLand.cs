using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeSetterOnPlayerLand : MonoBehaviour
{
    public Volume volume;
    public float startVolumeWeight = 0;
    private void Start()
    {
        volume.weight = startVolumeWeight;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            StartCoroutine(SetVolumeHeightTo1ASync());
        }
    }
    IEnumerator SetVolumeHeightTo1ASync()
    {
        while (volume.weight<1)
        {
            volume.weight += .1f;
            yield return new WaitForSeconds(.5f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(SetVolumeHeightTo0ASync());
        }
    }
    IEnumerator SetVolumeHeightTo0ASync()
    {
        while (volume.weight>0)
        {
            volume.weight -= .1f;
            yield return new WaitForSeconds(.5f);
        }
    }
}
