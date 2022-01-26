using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDeactivationScript : MonoBehaviour
{
    public GameObject barrier;
    public int targetLight = 2;
    Color NormalColor;
    [ColorUsage(false,true)] public Color DeactivationColor;
    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DeactiveBarrier());
        }
    }
    IEnumerator DeactiveBarrier()
    {
        int x = 0;
        Renderer rend = barrier.GetComponent<Renderer>();
        NormalColor = rend.material.GetColor("_mainColor");

        while (x<targetLight)
        {
            
                rend.material.SetColor("_mainColor", Color.Lerp(NormalColor, DeactivationColor, 50f));
            
            x++;
            yield return new WaitForSeconds(.5f);
        }
        barrier.SetActive(false);
    }
}
