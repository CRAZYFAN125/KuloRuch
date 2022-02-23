using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    [System.Serializable]
    public class ColorRendPP
    {
        [ColorUsage(true,true)]public Color color;
        public string variable = "MainColor_";
    }

    [SerializeField] ColorRendPP[] colorRends;

    public void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            foreach (ColorRendPP item in colorRends)
            {
                StartCoroutine(ChangeColorByLerp(item));
            }
        }
    }
    IEnumerator ChangeColorByLerp(ColorRendPP colorRend)
    {
        Renderer renderer = GetComponent<Renderer>();
        float sek = 0;

        while (renderer.material.GetColor(colorRend.variable)!=colorRend.color)
        {
            renderer.material.SetColor(colorRend.variable, Color.Lerp(renderer.material.GetColor(colorRend.variable), colorRend.color, sek / 10f));
            sek += .01f;
            yield return new WaitForSeconds(.01f);
        }
    }
}
